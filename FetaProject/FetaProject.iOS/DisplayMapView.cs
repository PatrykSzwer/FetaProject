using CoreGraphics;
using CoreLocation;
using Google.Maps;
using System;
using System.Collections.Generic;
using System.Xml;
using UIKit;

namespace FetaProject.iOS
{
    public partial class DisplayMapView : UIViewController
    {
        private MapView _mapView;
		public string a = "";
		public double b = 0.0;
		public double c = 0.0; 
        private readonly Dictionary<string, string> _maps = new Dictionary<string, string>
            {
                {"13.07", "https://www.google.com/maps/d/kml?mid=1AawIPxHphPSojHFvtVoG3XEVW1I&forcekml=1&cid=mp&cv=sEUwvjl8K84.pl."}, // Thursday
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
			else if (a == "")
			{
				LoadMap("13.07");
			}
			else
			{ 
                LoadMap("13.07");
			}
        }

        public void LoadMap(string mapId)
        {
			

            _mapView?.Clear();

            // Load map from KML file
            var doc = new XmlDocument();
            doc.Load(_maps[mapId]);

            // Get list of nodes from loaded KML file
            XmlNodeList idNodes = doc.GetElementsByTagName("Placemark");

            var marker = new Marker();
            var placemarks = new List<Marker>();

            placemarks = ReadMarkers(idNodes, placemarks, marker);

            CameraPosition camera = GetCameraPositionForMap(marker, placemarks);

            _mapView = MapView.FromCamera(CGRect.Empty, camera);
            _mapView.MyLocationEnabled = true;

            // Push markers onto mapView
            foreach (var iMarker in placemarks)
            {
                iMarker.Icon = UIImage.FromBundle("mapMarker.png");
                iMarker.Map = _mapView;
            }

            View = _mapView;


 			       
		}

        private static CameraPosition GetCameraPositionForMap(Marker marker, IEnumerable<Marker> placemarks)
        {
            // Calculation best view for map
            double maxLat = marker.Position.Latitude;
            double minLat = marker.Position.Latitude;
            double maxLng = marker.Position.Longitude;
            double minLng = marker.Position.Longitude;

            foreach (var mark in placemarks)
            {
                if (mark.Position.Latitude > maxLat)
                    maxLat = mark.Position.Latitude;

                if (minLat > mark.Position.Latitude)
                    minLat = mark.Position.Latitude;

                if (mark.Position.Longitude > maxLng)
                    maxLng = mark.Position.Longitude;

                if (minLng > mark.Position.Longitude)
                    minLng = mark.Position.Longitude;
            }

            // Ustawianie widoku mapy
            // srednia z wszysztkich markerów
            // CLLocationCoordinate2D location = new CLLocationCoordinate2D((maxLat + minLat) / 2, (maxLng + minLng) / 2);

            var camera = CameraPosition.FromCamera((maxLat + minLat) / 2, (maxLng + minLng) / 2, zoom: 15);
            return camera;
        }

        private static List<Marker> ReadMarkers(XmlNodeList nodeList, List<Marker> placemarks, Marker marker)
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
                        marker.Position = new CLLocationCoordinate2D(Convert.ToDouble(coordinates[1]), Convert.ToDouble(coordinates[0]));
                        marker = Marker.FromPosition(marker.Position);
                        break;
                    default:
                        ReadMarkers(node.ChildNodes, placemarks, marker);
                        break;
                }

                if (marker.Position.Latitude > 0 && marker.Title != null)
                {
                    placemarks.Add(marker);
                    marker = new Marker();
                }
            }

            return placemarks;
        }
    }
}