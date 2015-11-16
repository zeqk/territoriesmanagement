using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using TerritoriesManagement.Model;

namespace TerritoriesManagement.GUI.Maps
{
    public static class MapsHelper
    {


		public static MemoryStream GenerateTerritoriesImage(IList<Territory> territories)
		{

			var markers = new List<GMapMarker>();
			var polygons = new List<GMapPolygon>();
			var points = new List<PointLatLng>();

			foreach (var t in territories)
			{
				var polygon = GetPolygon(t.Area);
				polygon.Tag = t.Number.HasValue ? t.Number.Value.ToString() : null;
				polygons.Add(polygon);
				points.AddRange(polygon.Points);
				
			}

			var area = Helper.CalculateRectangle(points);

			var rv = MapsHelper.GenerateImageStream(area, 12, GMapProviders.GoogleMap, markers, polygons);

			return rv;
		}

        public static MemoryStream GenerateTerritoryImage(Territory territory)
        {

            var polygon = GetPolygon(territory.Area);

            var area = Helper.CalculateRectangle(polygon.Points);

            var polygons = new List<GMapPolygon>();
            polygons.Add(polygon);

            var markers = new List<GMapMarker>();

            foreach (var item in territory.Addresses)
            {

                if (item.Lat.HasValue && item.Lng.HasValue)
                {
                    GMapMarkerCustom marker = new GMapMarkerCustom(new PointLatLng(item.Lat.Value, item.Lng.Value));

                    if (item.InternalTerritoryNumber.HasValue)
                        marker.Tag = item.InternalTerritoryNumber.Value;
                    marker.Size = new System.Drawing.Size(4, 4);
                    markers.Add(marker);
                }
            }

            var rv = MapsHelper.GenerateImageStream(area, 15, GMapProviders.GoogleMap, markers, polygons);

            return rv;
        }

        public static  GMapPolygon GetPolygon(string areaStr)
        {
            List<PointLatLng> auxPoints = new List<PointLatLng>();
            if (areaStr != null)
                auxPoints = Helper.StrPointsToPointsLatLng(areaStr.Split('\n'));

            GMapPolygon polygon = new GMapPolygon(auxPoints, "");
            Pen pen = polygon.Stroke;
            pen.Color = Color.FromArgb(155, Color.Red);
            polygon.Stroke = pen;

            return polygon;
        }

        public static MemoryStream GenerateImageStream(RectLatLng area, int zoom, GMapProvider type, IList<GMapMarker> markers, IList<GMapPolygon> polygons)
        {
            MemoryStream rv = null;
            if (!area.IsEmpty)
            {

                // current area
                GPoint topLeftPx = type.Projection.FromLatLngToPixel(area.LocationTopLeft, zoom);
                GPoint rightButtomPx = type.Projection.FromLatLngToPixel(area.Bottom, area.Right, zoom);
                GPoint pxDelta = new GPoint(rightButtomPx.X - topLeftPx.X, rightButtomPx.Y - topLeftPx.Y);
                GMap.NET.GSize maxOfTiles = type.Projection.GetTileMatrixMaxXY(zoom);

                int padding = 22;
                {
                    using (Bitmap bmp = new Bitmap((int)(pxDelta.X + padding * 2), (int)(pxDelta.Y + padding * 2)))
                    {
                        using (Graphics gfx = Graphics.FromImage(bmp))
                        {
                            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            gfx.SmoothingMode = SmoothingMode.HighQuality;

                            int i = 0;
                            List<GPoint> tileArea = new List<GPoint>();
                            // get tiles & combine into one
                            lock (tileArea)
                            {
                                tileArea.Clear();
                                tileArea.AddRange(type.Projection.GetAreaTileList(area, zoom, 1));
                                tileArea.TrimExcess();

                                foreach (var p in tileArea)
                                {

                                    foreach (var tp in type.Overlays)
                                    {
                                        Exception ex;
                                        GMapImage tile;

                                        // tile number inversion(BottomLeft -> TopLeft) for pergo maps
                                        if (tp.InvertedAxisY)
                                        {
                                            tile = GMaps.Instance.GetImageFrom(tp, new GPoint(p.X, maxOfTiles.Height - p.Y), zoom, out ex) as GMapImage;
                                        }
                                        else // ok
                                        {
                                            tile = GMaps.Instance.GetImageFrom(tp, p, zoom, out ex) as GMapImage;
                                        }

                                        if (tile != null)
                                        {
                                            using (tile)
                                            {
                                                long x = p.X * type.Projection.TileSize.Width - topLeftPx.X + padding;
                                                long y = p.Y * type.Projection.TileSize.Width - topLeftPx.Y + padding;
                                                {
                                                    gfx.DrawImage(tile.Img, x, y, type.Projection.TileSize.Width, type.Projection.TileSize.Height);
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            // draw polygons
                            {
                                foreach (GMapPolygon polygon in polygons)
                                {
                                    if (polygon.IsVisible)
                                    {
                                        using (GraphicsPath rp = new GraphicsPath())
                                        {
                                            for (int j = 0; j < polygon.Points.Count; j++)
                                            {
                                                var pr = polygon.Points[j];
                                                GPoint px = type.Projection.FromLatLngToPixel(pr.Lat, pr.Lng, zoom);

                                                px.Offset(padding, padding);
                                                px.Offset(-topLeftPx.X, -topLeftPx.Y);

                                                GPoint p2 = px;

                                                if (j == 0)
                                                {
                                                    rp.AddLine(p2.X, p2.Y, p2.X, p2.Y);
                                                }
                                                else
                                                {
                                                    System.Drawing.PointF p = rp.GetLastPoint();
                                                    rp.AddLine(p.X, p.Y, p2.X, p2.Y);
                                                }
                                            }

											

                                            Color color = Color.FromArgb(95, polygon.Stroke.Color);
                                            Pen pen = new Pen(color, 4);
                                            pen.DashStyle = DashStyle.Custom;

                                            if (rp.PointCount > 0)
                                            {
                                                rp.CloseFigure();

                                                gfx.DrawPolygon(pen, rp.PathPoints);
                                            }
											
											if (polygon.Tag != null)
											{
												var center = Helper.CalculateCenter(polygon.Points);
												GPoint pxCenter = type.Projection.FromLatLngToPixel(center.Lat, center.Lng, zoom);
												pxCenter.Offset(padding, padding);
												
												//pxCenter.Offset(-topLeftPx.X, -topLeftPx.Y);

												var x = Convert.ToInt32(pxCenter.X);
												var y = Convert.ToInt32(pxCenter.Y);

												Font font = new Font(FontFamily.GenericSansSerif, 20);
												
												var infoTag = polygon.Tag.ToString();
												gfx.DrawString(infoTag, font, Brushes.Red, x, y);
											}
                                        }
                                    }
                                }
                            }


                            //draw marks
                            foreach (var marker in markers)
                            {

                                var pr = marker.Position;
                                GPoint px = type.Projection.FromLatLngToPixel(pr.Lat, pr.Lng, zoom);

                                px.Offset(padding, padding);
                                px.Offset(-topLeftPx.X, -topLeftPx.Y);
                                px.Offset(marker.Offset.X, marker.Offset.Y);

                                IntPtr iconHandle1 = TerritoriesManagement.GUI.Properties.Resources.legendIcon.GetHicon();
                                if (marker.GetType().GetProperty("Icon") != null)
                                {
                                    Bitmap bitmap = (Bitmap)marker.GetType().GetProperty("Icon", typeof(Bitmap)).GetValue(marker, null);
                                    if (bitmap != null) iconHandle1 = bitmap.GetHicon();
                                }

                                Icon icon1 = Icon.FromHandle(iconHandle1);
                                var x = Convert.ToInt32(px.X);
                                var y = Convert.ToInt32(px.Y);
                                gfx.DrawIcon(icon1, x - (icon1.Size.Width / 2), y - (icon1.Size.Height / 2));
                                								                               
								if (marker.Tag != null)
								{
									var infoTag = marker.Tag.ToString();
									Font font = new Font(FontFamily.GenericSansSerif, 12);
									gfx.DrawString(infoTag, font, Brushes.Red, x + 10, y - 10);
								}
                            }

                        }

                        if (bmp.Height > bmp.Width)
                            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);

                        var ms = new System.IO.MemoryStream();
                        bmp.Save(ms, ImageFormat.Png);

                        rv = ms;

                    }
                }
            }

            return rv;
        }

    }
}
