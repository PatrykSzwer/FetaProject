using System;
using System.Collections.Generic;
using System.Xml;
using UIKit;
using CoreLocation;
using System.Reflection;
using System.IO;

namespace FetaProject.iOS
{
    public partial class MapViewController : UIViewController
    {

		public string a = "";
		public double b = 0.0;
		public double c = 0.0;
        public bool userLocation = false;

        CLLocationManager locationManager = new CLLocationManager();

		private readonly Dictionary<int, string> _eventsDayMapper = new Dictionary<int, string>
        {
            {0, "13.07"},
            {1, "14.07"},
            {2, "15.07"},
            {3, "16.07"}
        };

		public string _mapId = "13.07";

		private readonly Dictionary<string, string> _maps = new Dictionary<string, string>
			{
				{"13.07", "FetaProject.iOS.Resources.Maps.dayMap1.kml"}, // Thursday
                {"14.07", "FetaProject.iOS.Resources.Maps.dayMap2.kml"}, // Friday
                {"15.07", "FetaProject.iOS.Resources.Maps.dayMap3.kml"}, // Saturday
                {"16.07", "FetaProject.iOS.Resources.Maps.dayMap4.kml"}, // Sunday
                {"Utilities", "FetaProject.iOS.Resources.Maps.Utilities.kml"} // Sunday

            };

		NetworkStatus internetStatus = Reachability.InternetConnectionStatus();

        public override void ViewDidLoad()
        {
			base.ViewDidLoad();


			if (!Reachability.IsHostReachable("http://google.com"))
			{
				map.Image = UIImage.FromBundle("Photo/Map.jpg");
			}
			else
			{
				LoadMap(_mapId);
			}

            if (!userLocation)
            {
				locationManager.RequestWhenInUseAuthorization();
                userLocation = true;
			}
                
            SelectDay.ValueChanged += SegmentChange;
            OthersButton.TouchUpInside += delegate {
				_mapId = "Utilities";
				mainMapView.RemoveAnnotations(mainMapView.Annotations);
				LoadMap(_mapId);
            };
        }

        public MapViewController(IntPtr handle) : base(handle)
        {

        }

        private void SegmentChange(object sender, EventArgs e)
        {
            var selectedSegmentId = (int)(sender as UISegmentedControl).SelectedSegment;
            _mapId = _eventsDayMapper[selectedSegmentId];
            mainMapView.RemoveAnnotations(mainMapView.Annotations);
            LoadMap(_mapId);
        }

		public void LoadMap(string mapId)
		{

            Assembly _assembly = Assembly.GetExecutingAssembly();
            Stream _fileStream = _assembly.GetManifestResourceStream(_maps[mapId]);

			// Load map from KML file
			var doc = new XmlDocument();
            doc.Load(_fileStream);


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

			var coordinate = new CoreLocation.CLLocationCoordinate2D((maxLat + minLat) / 2, (maxLng + minLng) / 2);
			var span = new MapKit.MKCoordinateSpan((maxLat - minLat) * 2, (maxLng - minLng) * 2);
			var region = new MapKit.MKCoordinateRegion(coordinate, span);
			mainMapView.SetRegion(region, true);
			mainMapView.ShowsUserLocation = true;

			foreach (var mark in placemarks)
				mainMapView.AddAnnotations(mark);

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