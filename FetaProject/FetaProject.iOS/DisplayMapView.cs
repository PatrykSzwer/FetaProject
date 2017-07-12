using CoreGraphics;
using CoreLocation;
using System;
using System.Collections.Generic;
using System.Xml;
using UIKit;

namespace FetaProject.iOS
{
    public partial class DisplayMapView : UIViewController
    {

		public string _mapId = "13.07";
 
        private readonly Dictionary<string, string> _maps = new Dictionary<string, string>
            {
                {"13.07", "https://www.google.com/maps/d/kml?mid=1i6zeG6kvMcUdFBgTQ7DY2WIhAfU&forcekml=1&cid=mp&cv=AQL2q8XZHY8.pl."}, // Thursday
                {"14.07", "https://www.google.com/maps/d/kml?forcekml=1&mid=15gRIrjBFGwj-aJXzkoB6AMIXTG4"}, // Friday
                {"15.07", "https://www.google.com/maps/d/kml?forcekml=1&mid=15gRIrjBFGwj-aJXzkoB6AMIXTG4"}, // Saturday
                {"16.07", "https://www.google.com/maps/d/kml?mid=1AawIPxHphPSojHFvtVoG3XEVW1I&forcekml=1&cid=mp&cv=sEUwvjl8K84.pl."}, // Sunday
                {"Utilities", "https://www.google.com/maps/d/kml?mid=1AawIPxHphPSojHFvtVoG3XEVW1I&forcekml=1&cid=mp&cv=sEUwvjl8K84.pl."} // Sunday

            };

        NetworkStatus internetStatus = Reachability.InternetConnectionStatus();

        public DisplayMapView(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {

            base.ViewDidLoad();
			
			    
			if (!Reachability.IsHostReachable("http://google.com"))
			{
				//map.Image = UIImage.FromBundle("Photo/Map.jpg");
			}
			else
			{ 
               LoadMap(_mapId);
			}

        }

        public void LoadMap(string mapId)
        {
			//map?.Dispose();
           

            // Load map from KML file
            var doc = new XmlDocument();
            doc.Load(_maps[mapId]);

            // Get list of nodes from loaded KML file
            XmlNodeList idNodes = doc.GetElementsByTagName("Placemark");

            var marker = new MapKit.MKPointAnnotation();
            var placemarks = new List<MapKit.MKPointAnnotation>();

            placemarks = ReadMarkers(idNodes, placemarks, marker);

            CenterMap(marker, placemarks);

 			       
		}

        private void CenterMap(MapKit.MKPointAnnotation marker, IEnumerable<MapKit.MKPointAnnotation> placemarks)
        {
            // Calculation best view for map
            double maxLat = marker.Coordinate.Latitude;
            double minLat = marker.Coordinate.Latitude;
            double maxLng = marker.Coordinate.Longitude;
            double minLng = marker.Coordinate.Longitude;

            foreach (var mark in placemarks)
            {
                if (mark.Coordinate.Latitude > maxLat)
                    maxLat = mark.Coordinate.Latitude;

                if (minLat > mark.Coordinate.Latitude)
                    minLat = mark.Coordinate.Latitude;

                if (mark.Coordinate.Longitude > maxLng)
                    maxLng = mark.Coordinate.Longitude;

                if (minLng > mark.Coordinate.Longitude)
                    minLng = mark.Coordinate.Longitude;
            }

            // Ustawianie widoku mapy
            // srednia z wszysztkich markerów
            // CLLocationCoordinate2D location = new CLLocationCoordinate2D((maxLat + minLat) / 2, (maxLng + minLng) / 2);

            var coordinate = new CoreLocation.CLLocationCoordinate2D((maxLat + minLat) / 2, (maxLng + minLng) / 2);
            var span = new MapKit.MKCoordinateSpan((maxLat - minLat)*2, (maxLng - minLng)*2);
            var region = new MapKit.MKCoordinateRegion(coordinate, span);
            //mainMapView.SetRegion(region, true);
            //mainMapView.ShowsUserLocation = true;

            //foreach(var mark in placemarks)
            //mainMapView.AddAnnotations(mark);

        }

        private static List<MapKit.MKPointAnnotation> ReadMarkers(XmlNodeList nodeList, List<MapKit.MKPointAnnotation> placemarks, MapKit.MKPointAnnotation marker)
        {
            foreach (XmlNode node in nodeList)
            {
                switch (node.Name)
                {
                    case "name":
                        marker.Title = node.FirstChild.Value;
                        break;
                    case "coordinates":
                        var coordinates = node.FirstChild.Value.Split(',');
                        double latitude = 0, longtitude = 0, temp;
                        if (double.TryParse(coordinates[1], out temp))
                            latitude = temp;
                        if (double.TryParse(coordinates[0], out temp))
                            longtitude = temp;
                        marker.Coordinate = new CLLocationCoordinate2D(latitude, longtitude);
                        break;
                    default:
                        ReadMarkers(node.ChildNodes, placemarks, marker);
                        break;
                }

                if (marker.Coordinate.Latitude > 0 && marker.Title != null)
                {
                    placemarks.Add(marker);
                    marker = new MapKit.MKPointAnnotation();
                }
            }

            return placemarks;
        }
    }
}