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

        public void OnMapReady(GoogleMap googleMap)
        {
            MarkerOptions markerOptions = new MarkerOptions();
            markerOptions.SetPosition(new LatLng(54.7509615, 17.5710568));
            markerOptions.SetTitle("My position");
            googleMap.AddMarker(markerOptions);

            //Option
            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;
            googleMap.MoveCamera(CameraUpdateFactory.ZoomIn());
        }

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            //SetContentView (Resource.Layout.Main);

            SetContentView(Resource.Layout.Map);
            MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);


            // Get our button from the layout resource,
            // and attach an event to it
         /*   Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} FETA clicks!", count++);
			}; */
		}
	}
}


