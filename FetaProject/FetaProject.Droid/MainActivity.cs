using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace FetaProject.Droid
{
	[Activity (Label = "FetaProject.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, IOnMapReadyCallback
	{
		int count = 1;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            //SetContentView (Resource.Layout.Main);

            //Ustawianie i wyswietlanie layout'u Mapy
            //trzeba to bedzie podpiac pod przycisk menu
            SetContentView(Resource.Layout.Map);
            MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);
            GoogleMap map = mapFragment.Map;
            if (map != null) { }

            // Get our button from the layout resource,
            // and attach an event to it
            /*   Button button = FindViewById<Button> (Resource.Id.myButton);

               button.Click += delegate {
                   button.Text = string.Format ("{0} FETA clicks!", count++);
               }; */
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            //Ustawianie widoku mapy
            LatLng location = new LatLng(54.7509615, 17.5710568);       //te wartosci warto bedzie wyciagac srednia z markerow
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(15);
            //builder.Bearing(155);
            builder.Tilt(30);                                       //kat pochylenia 
            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            //Ustawianie markera
            //trzeba przygotować czytnik do robienia listy wrzucajacej wiecej markerow na mapie
            MarkerOptions markerOptions = new MarkerOptions();
            markerOptions.SetPosition(new LatLng(54.7509615, 17.5710568));
            markerOptions.SetTitle("My position");
            googleMap.AddMarker(markerOptions);

            //Opcje mapy i update'y
            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;
            googleMap.MoveCamera(CameraUpdateFactory.ZoomIn());
            googleMap.MoveCamera(cameraUpdate);
        }
    }
}


