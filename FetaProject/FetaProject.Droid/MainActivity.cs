using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Android.Media;

namespace FetaProject.Droid
{
	[Activity (Label = "FetaProject.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, IOnMapReadyCallback
    {
        
        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);



            // Get our button from the layout resource,
            // and attach an event to it
               Button button = FindViewById<Button> (Resource.Id.btnMap);

               button.Click += delegate {
                   SetUpMap();
               }; 
        }


        public void SetUpMap()
        {
            //Ustawianie i wyswietlanie layout'u Mapy
            //trzeba to bedzie podpiac pod przycisk w menu
            SetContentView(Resource.Layout.Map);
            FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            //Ustawianie widoku mapy
            LatLng location = new LatLng(54.3409615, 18.6410568);       //te wartosci warto bedzie wyciagac srednia z markerow
           
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(15);
            builder.Tilt(30);                                       //kat pochylenia 
            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            //Ustawianie markera
            //trzeba przygotować czytnik do robienia listy wrzucajacej wiecej markerow na mapie
            MarkerOptions markerOptions = new MarkerOptions();
           
            //przykładowe preferencje markerów 
            //.SetPosition(new LatLng(54.7509615, 17.5710568))
            //.SetTitle("My position")
            //.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueGreen));


            //Wczytywanie pliku mapy (KML)
            XmlDocument doc = new XmlDocument();
            //doc.Load(Assets.Open("a.kml"));
            //CZWARTEK doc.Load("https://www.google.com/maps/d/kml?mid=1YAdsxSz644qe4F90BerIaSeENgk&forcekml=1");
            //PIATEK doc.Load("https://www.google.com/maps/d/kml?mid=1U_fAWaQwaIVGbZ1lk-TC9Bxn7n0&forcekml=1");
            //SOBOTA doc.Load("https://www.google.com/maps/d/kml?mid=1eABjtJfl-31WyggXycwIRsAI_d4&forcekml=1");
            //NIEDZIELA 
            doc.Load("https://www.google.com/maps/d/kml?mid=1W2wGEBUezDja1qdDTG85fxicUNA&forcekml=1");


            XmlNodeList idNodes = doc.GetElementsByTagName("Placemark");
            List<MarkerOptions> placemarks = new List<MarkerOptions>();
            placemarks = ReadMarkers(idNodes, placemarks, markerOptions);

            //wrzucanie listy markerow na mape
            foreach (var marker in placemarks)
            {
                //marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin));   //konkretna ikona 
                marker.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueGreen));

                googleMap.AddMarker(marker);
                Console.WriteLine("MARKER :" + marker.Title + " : " + marker.Position + " : " + marker.Snippet + "\r\n");
            }


            //Opcje mapy i update'y
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
                    //Console.WriteLine(node.Name + " = " + node.FirstChild.Value + "\r\n");
                }
                else if (node.Name == "coordinates")
                {
                    coordinates = node.FirstChild.Value.Split(',');
                    marker.SetPosition(new LatLng(Convert.ToDouble(coordinates[1]), Convert.ToDouble(coordinates[0])));
                    //Console.WriteLine("cor1: {0}, cor2: {1}", Convert.ToDouble(coordinates[1]), Convert.ToDouble(coordinates[0]));
                }
                else if (node.Name == "description")
                {
                    marker.SetSnippet(node.FirstChild.Value);
                    //Console.WriteLine(node.Name + " = " + node.FirstChild.Value + "\r\n");
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


