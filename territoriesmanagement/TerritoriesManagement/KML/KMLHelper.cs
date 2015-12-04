using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using TerritoriesManagement.DataBridge;
using TerritoriesManagement.Model;

namespace TerritoriesManagement.KML
{
	public class KMLHelper
	{


		#region Import new territories from KML

		public static void ImportNewTerritories(string kmlFile)
		{
			var bridge = new Territories();

			bridge.DeleteAll();

			ImportTerritoriesFromKml(kmlFile);

			bridge.AsignTerritoriesToAddresses();
			bridge.RenumInternalTerritoryNumber();
		}


		

		static void ImportTerritoriesFromKml(string kmlFile)
		{
			KmlFile file = null;
			using (var stream = System.IO.File.OpenRead(kmlFile))
			{
				file = KmlFile.Load(stream);

			}

			TerritoriesDataContext dm = new TerritoriesDataContext();
			var format = CultureInfo.GetCultureInfo("en-US").NumberFormat;

			Kml kml = file.Root as Kml;
			if (kml != null)
			{
				foreach (var placemark in kml.Flatten().OfType<SharpKml.Dom.Placemark>())
				{
					var polygon = placemark.Flatten().OfType<Polygon>().FirstOrDefault();
					if (polygon != null)
					{
						var boundary = polygon.OuterBoundary.LinearRing.Coordinates.Select(r => r.Latitude.ToString(format) + " " + r.Longitude.ToString(format)).ToArray();
						var area = string.Join(Environment.NewLine, boundary);
						var territory = new Territory
						{
							Name = placemark.Name,
							Area = area
						};
						dm.AddToTerritories(territory);
					}
				}
			}
			dm.SaveChanges();
		}
		#endregion


        public static void ExportTerritoriesToKml(Expression<Func<Territory,bool>> whereExp, string path, bool singleFile)
        {
            try
            {
                var bridge = new Territories();
                var territories = bridge.Search(whereExp);

                if (singleFile)
                {
                    Document doc = new Document();

                    foreach (var t in territories)
                    {
                        var placemarks = TerritoryToPlacemarks(t);
                        foreach (var p in placemarks)
                        {
                            doc.AddFeature(p);
                        }
                    }


                    Kml kml = new Kml();
                    kml.Feature = doc;
                    // This allows us to save and Element easily.
                    KmlFile file = KmlFile.Create(kml, false);
                    using (var stream = System.IO.File.OpenWrite(path))
                    {
                        file.Save(stream);

                    }
                }
                else
                {
                    foreach (var t in territories) 
                    {
                        var name = (t.Number.HasValue ? t.Number.Value.ToString() : string.Empty) + t.Name;
                        var file = Path.Combine(path, name + ".kml");
                        ExportTerritoryToKml(t, file);
                    }
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void ExportTerritoryToKml(Territory territory, string path)
        {
            try
            {
                var bridge = new Territories();

                Document doc = new Document();
                var placemarks = TerritoryToPlacemarks(territory);
                foreach (var p in placemarks)
                {
                    doc.AddFeature(p);
                }


                Kml kml = new Kml();
                kml.Feature = doc;
                // This allows us to save and Element easily.
                KmlFile file = KmlFile.Create(kml, false);
                using (var stream = System.IO.File.OpenWrite(path))
                {
                    file.Save(stream);

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        static IList<SharpKml.Dom.Placemark> TerritoryToPlacemarks(Territory t)
        {
            var rv = new List<SharpKml.Dom.Placemark>();


            if (!string.IsNullOrEmpty(t.Area))
            {

                var polygon = new Polygon();
                polygon.OuterBoundary = new OuterBoundary();
                polygon.OuterBoundary.LinearRing = new LinearRing();
                polygon.OuterBoundary.LinearRing.Tessellate = true;
                polygon.OuterBoundary.LinearRing.Coordinates = new CoordinateCollection();


                var points = Helper.StrPointsToPointsLatLng(t.Area.Split('\n'));

                foreach (var p in points)
                {
                    polygon.OuterBoundary.LinearRing.Coordinates.Add(new Vector() { Latitude = p.Lat, Longitude = p.Lng, Altitude = 0 });
                }                


                var territoryName = (t.Number.HasValue ? t.Number.Value.ToString() + " - " : string.Empty) + t.Name;
                // This is the Element we are going to save to the Kml file.
                var placemark = new SharpKml.Dom.Placemark();
                
                placemark.Geometry = polygon;
                placemark.Name = territoryName;
                placemark.Description = new Description();
                placemark.Description.Text = territoryName;
                placemark.ExtendedData = new ExtendedData();

                rv.Add(placemark);
            }

            if(!t.Addresses.IsLoaded)
                t.Addresses.Load();

            foreach (var a in t.Addresses)
            {
                if (a.Lng.HasValue && a.Lng.HasValue)
                {
                    a.CityReference.Load();
                    a.City.DepartmentReference.Load();
                    string address = a.Street + " " + a.Number;
                    string fullAddress = address + ", " + a.City.Name + ", " + a.City.Department.Name + Environment.NewLine
                        + (!string.IsNullOrEmpty(a.Corner1) ? " Entre: " + a.Corner1 + (!string.IsNullOrEmpty(a.Corner2) ? " y " + a.Corner2 : string.Empty) : string.Empty);


                    var point = new Point();
                    point.Coordinate = new Vector(a.Lat.Value, a.Lng.Value);
                    
                    var placemark = new SharpKml.Dom.Placemark();
                    placemark.Geometry = point;
                    placemark.Name = (a.InternalTerritoryNumber.HasValue ? a.InternalTerritoryNumber.Value.ToString() + " - " : string.Empty) + address;
                    placemark.Address = address;
                    placemark.Description = new Description();
                    placemark.Description.Text = fullAddress;

                    rv.Add(placemark);
                }
            }

            return rv;
        }
	}
}
