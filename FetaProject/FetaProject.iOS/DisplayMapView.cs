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
        private readonly Dictionary<string, string> _maps = new Dictionary<string, string>
            {
                {"13.07", "https://www.google.com/maps/d/kml?mid=1AawIPxHphPSojHFvtVoG3XEVW1I&forcekml=1&cid=mp&cv=sEUwvjl8K84.pl."}, // Thursday
                {"14.07", "https://www.google.com/maps/d/kml?forcekml=1&mid=15gRIrjBFGwj-aJXzkoB6AMIXTG4"}, // Friday
                {"15.07", "https://www.google.com/maps/d/kml?forcekml=1&mid=15gRIrjBFGwj-aJXzkoB6AMIXTG4"}, // Saturday
                {"16.07", "https://www.google.com/maps/d/kml?mid=1AawIPxHphPSojHFvtVoG3XEVW1I&forcekml=1&cid=mp&cv=sEUwvjl8K84.pl."}, // Sunday
                {"Utilities", "https://www.google.com/maps/d/kml?mid=1AawIPxHphPSojHFvtVoG3XEVW1I&forcekml=1&cid=mp&cv=sEUwvjl8K84.pl."} // Sunday

            };

        private string selector = "13.07";
        private MapView mapView;
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
                LoadMap(selector);
            }

        }

        public void Test(string newSelector)
        {
            this.selector = newSelector;
            this.ViewDidLoad();
        }

        public void LoadMap(string mapId)
        {
            mapView?.Clear();

            //Wczytywanie pliku mapy (KML)
            XmlDocument doc = new XmlDocument();

            doc.Load(_maps[mapId]);

            //lista elemtow z XML ktore nas interesuja
            XmlNodeList idNodes = doc.GetElementsByTagName("Placemark");
            //Marker
            Marker marker = new Marker();
            List<Marker> placemarks = new List<Marker>();
            //wpisane w liste markerow
            placemarks = ReadMarkers(idNodes, placemarks, marker);


            //obliczanie najlepszego widoku dla mapy
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

            //Ustawianie widoku mapy
            //œrednia z wszysztkich markerów
            CLLocationCoordinate2D location = new CLLocationCoordinate2D((maxLat + minLat) / 2, (maxLng + minLng) / 2);
            //Console.WriteLine(location);			
            CameraPosition camera = CameraPosition.FromCamera((maxLat + minLat) / 2, (maxLng + minLng) / 2, zoom: 15);
            //CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(camera);
            //CameraUpdate cameraUpdate = CameraUpdate.
            mapView = MapView.FromCamera(CGRect.Empty, camera);
            mapView.MyLocationEnabled = true;

            //wrzucanie listy markerow na mape
            foreach (var iMarker in placemarks)
            {

                //iMarker.Icon = (BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueGreen));

                //iMarker.Map = mapView;
                //googleMap.AddMarker(iMarker);
                iMarker.Icon = UIImage.FromBundle("mapMarker.png");
                iMarker.Map = mapView;
            }

            //Opcje mapy i update'y
            //trzeba bedzie dodac obsluge nawigacji
            //mapView.Settings.ZoomGestures = true;// google.UiSettings.ZoomControlsEnabled = true;
            //mapView.Settings.AllowScrollGesturesDuringRotateOrZoom = true;
            //googleMap.UiSettings.CompassEnabled = true;
            //googleMap.MoveCamera(.ZoomIn());
            //googleMap.MoveCamera(cameraUpdate);

            View = mapView;
        }

        private List<Marker> ReadMarkers(XmlNodeList nodeList, List<Marker> placemarks, Marker marker)
        {
            //zmienna potrzebna do rozdzielania koordynatow
            string[] coordinates;


            foreach (XmlNode node in nodeList)
            {

                if (node.Name == "name")
                {
                    marker.Title = node.FirstChild.Value;


                }
                else if (node.Name == "coordinates")
                {
                    coordinates = node.FirstChild.Value.Split(',');
                    marker.Position = new CLLocationCoordinate2D(Convert.ToDouble(coordinates[1]), Convert.ToDouble(coordinates[0]));
                    marker = Marker.FromPosition(marker.Position);
                }
                //optional description under the marker
                // można dobrać informacje które chcemy wyświetlać pod markerem (jak poniżej w ReadEvents)
                /*else if (node.Name == "description")
				{
					marker.Snippet = node.FirstChild.Value;
				}*/
                else
                {
                    ReadMarkers(node.ChildNodes, placemarks, marker);
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