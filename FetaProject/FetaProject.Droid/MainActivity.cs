using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using SupportTooblar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.App;
using Android.Support.V4.Widget;

namespace FetaProject.Droid
{
	[Activity (Label = "FetaProject.Droid", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/AppTheme")]
	public class MainActivity : ActionBarActivity, IOnMapReadyCallback
    {
        private SupportTooblar mToolbar;
        private LeftSideMenuHandler mLeftSideMenuHandler;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //Ustawianie i wyswietlanie layout'u Mapy
            //trzeba to bedzie podpiac pod przycisk menu
            /* SetContentView(Resource.Layout.Map);
             MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
             mapFragment.GetMapAsync(this); //jak narazie to odpala mape
             GoogleMap map = mapFragment.Map;
             if (map != null) { }
             */

            mToolbar = FindViewById<SupportTooblar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            SetSupportActionBar(mToolbar);

            mLeftSideMenuHandler = new LeftSideMenuHandler(
                this,                         //host activity
                mDrawerLayout,                //drawer layout
                Resource.String.openDrawer,   //Opened message
                Resource.String.closeDrawer   //Closed message
                );

            //mDrawerLayout.SetDrawerListener(mLeftSideMenuHandler);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            mLeftSideMenuHandler.SyncState();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mLeftSideMenuHandler.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }

        public override void OnSaveInstanceState(Bundle outState, PersistableBundle outPersistentState)
        {
            base.OnSaveInstanceState(outState, outPersistentState);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            //Ustawianie widoku mapy
            LatLng location = new LatLng(54.7540398, 17.5678295);       //te wartosci warto bedzie wyciagac srednia z markerow
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
            markerOptions.SetPosition(new LatLng(54.7540398, 17.5678295));
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


