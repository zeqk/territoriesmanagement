using GMap.NET;
using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TerritoriesManagement.DataBridge;
using TerritoriesManagement.Model;

namespace TerritoriesManagement.KML
{
	public class KMLHelper
	{


		#region Import new territories from KML

		public static void ImportNewTerritories(string kmlFile)
		{
			RemoveOldTerritories();
			ImportTerritoriesFromKml(kmlFile);
			SetNewTerritories();
			RenumInternalTerritoryNumber();
		}

		static void RemoveOldTerritories()
		{
			TerritoriesDataContext dm = new TerritoriesDataContext();
			foreach (var item in dm.Addresses)
			{
				item.Territory = null;
				item.InternalTerritoryNumber = null;
			}
			dm.SaveChanges();
			dm.territories_DeleteAll();
            dm.territories_ResetId(0);
			dm.SaveChanges();
		}

		static void SetNewTerritories()
		{
			TerritoriesDataContext dm = new TerritoriesDataContext();
			
			foreach (var item in dm.Addresses)
			{
				if (item.Lat.HasValue && item.Lng.HasValue)
				{
					PointLatLng point = new PointLatLng(item.Lat.Value, item.Lng.Value);
					foreach (Territory t in dm.Territories)
					{
						if (t.Area != null && t.Area != "")
						{
							List<PointLatLng> polygon = Helper.StrPointsToPointsLatLng(t.Area.Split('\n'));
							if (Helper.PointInPolygon(point, polygon.ToArray()))
							{
								item.Territory = t;
								break;
							}
						}
					}
				}
			}
			dm.SaveChanges();
		}

		static void RenumInternalTerritoryNumber()
		{
			try
			{
				TerritoriesDataContext dm = new TerritoriesDataContext();

				foreach (var item in dm.Territories)
				{
					item.Addresses.Load();
					var addresses = item.Addresses.Where(a => a.Lat.HasValue && a.Lng.HasValue)
						.OrderByDescending(a => a.Lat.Value).ThenBy(a => a.Lng.Value).ToList();

					var i = 1;
					foreach (var a in addresses)
					{
						a.InternalTerritoryNumber = i;
						i++;
					}
				}
				dm.SaveChanges();
			}
			catch (Exception ex)
			{

				throw ex;
			}
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


        public static void ExportTerritoriesToKml(IList<TerritoryItem1> territories, string fileName)
        {
            try
            {
                Document doc = new Document();
                var i = 0;
                foreach (var t in territories)
                {
                    if (!string.IsNullOrEmpty(t.Area))
                    {


                        var polygon = new Polygon();
                        polygon.OuterBoundary = new OuterBoundary();
                        polygon.OuterBoundary.LinearRing = new LinearRing();
                        polygon.OuterBoundary.LinearRing.Coordinates = new CoordinateCollection();

                        var points = Helper.StrPointsToPointsLatLng(t.Area.Split('\n'));

                        foreach (var p in points)
                        {
                            polygon.OuterBoundary.LinearRing.Coordinates.Add(new Vector() { Latitude = p.Lat, Longitude = p.Lng });
                        }

                        

                        // This is the Element we are going to save to the Kml file.
                        var placemark = new SharpKml.Dom.Placemark();
                        placemark.Geometry = polygon;
                        placemark.Name = (t.Number.HasValue ? t.Number.Value.ToString() + " - " : string.Empty) + t.Name;
                        placemark.Description = new Description();
                        placemark.Description.Text = t.Number.HasValue ? t.Number.Value.ToString() + " - " : string.Empty;

                        doc.AddFeature(placemark);
                        i++;
                    }
                }



                // This allows us to save and Element easily.
                KmlFile kml = KmlFile.Create(doc, false);
                using (var stream = System.IO.File.OpenWrite(fileName))
                {
                    kml.Save(stream);

                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
	}
}
