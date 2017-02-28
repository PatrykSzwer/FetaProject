using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FetaProject.Droid
{
    [Activity(Label = "MapActivity")]
    public class MapActivity : Activity, IOnMapReadyCallback
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Map);
            FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
        }

        public void OnMapReady(GoogleMap googleMap)
        {

            //Wczytywanie pliku mapy (KML)
            XmlDocument doc = new XmlDocument();

            //default  doc.Load("https://www.google.com/maps/d/kml?mid="+w_tym_miejscu_musi_byc_hash_dowolnej_mapki+"&forcekml=1");


            //CZWARTEK  doc.Load("https://www.google.com/maps/d/kml?mid=1YAdsxSz644qe4F90BerIaSeENgk&forcekml=1");
            //PIATEK    doc.Load("https://www.google.com/maps/d/kml?mid=1U_fAWaQwaIVGbZ1lk-TC9Bxn7n0&forcekml=1");
            //SOBOTA    
            doc.Load("https://www.google.com/maps/d/kml?mid=1eABjtJfl-31WyggXycwIRsAI_d4&forcekml=1");
            //NIEDZIELA doc.Load("https://www.google.com/maps/d/kml?mid=1W2wGEBUezDja1qdDTG85fxicUNA&forcekml=1");

            //lista elemtow z XML ktore nas interesuja
            XmlNodeList idNodes = doc.GetElementsByTagName("Placemark");
            //Marker
            MarkerOptions marker = new MarkerOptions();
            List<MarkerOptions> placemarks = new List<MarkerOptions>();
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
            //�rednia z wszysztkich marker�w
            LatLng location = new LatLng((maxLat + minLat) / 2, (maxLng + minLng) / 2);

            CameraPosition.Builder mapView = CameraPosition.InvokeBuilder();
            mapView.Target(location);
            mapView.Zoom(15);
            mapView.Tilt(30);                                       //kat pochylenia 
            CameraPosition cameraPosition = mapView.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);


            //wrzucanie listy markerow na mape
            foreach (var iMarker in placemarks)
            {
                //marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin));     //konkretny plik z ikona 
                iMarker.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueGreen));

                googleMap.AddMarker(iMarker);
            }


            //Opcje mapy i update'y
            //trzeba bedzie dodac obsluge nawigacji
            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;
            googleMap.MoveCamera(CameraUpdateFactory.ZoomIn());
            googleMap.MoveCamera(cameraUpdate);
        }


        private List<MarkerOptions> ReadMarkers(XmlNodeList nodeList, List<MarkerOptions> placemarks, MarkerOptions marker)
        {
            //zmienna potrzebna do rozdzielania koordynatow
            string[] coordinates;

            foreach (XmlNode node in nodeList)
            {

                if (node.Name == "name")
                {
                    marker.SetTitle(node.FirstChild.Value);
                }
                else if (node.Name == "coordinates")
                {
                    coordinates = node.FirstChild.Value.Split(',');
                    marker.SetPosition(new LatLng(Convert.ToDouble(coordinates[1]), Convert.ToDouble(coordinates[0])));
                }
                else if (node.Name == "description")
                {
                    marker.SetSnippet(node.FirstChild.Value);
                }
                else
                {
                    ReadMarkers(node.ChildNodes, placemarks, marker);
                }

                if (marker.Position != null && marker.Title != null)
                {
                    placemarks.Add(marker);
                    marker = new MarkerOptions();
                }
            }
            return placemarks;
        }
    }
}