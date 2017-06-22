
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
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using BottomNavigationBar;




namespace FetaProject.Droid
{
    public class Event
    {
        public string TeatreName;
        public string ActName;
        public DateTime TimeEvent;
        public string OriginCountry;
        public string Description;
        public string Place;
        public double Longtitude;
        public double Latitude;
    }

    [Activity(Label = "MapActivity")]
	public class MapActivity : AppCompatActivity, BottomNavigationBar.Listeners.IOnMenuTabClickListener, IOnMapReadyCallback
	{
        private readonly Dictionary<string, string> _maps = new Dictionary<string, string>
            {
                {"13.07", "https://www.google.com/maps/d/kml?mid=1AawIPxHphPSojHFvtVoG3XEVW1I&forcekml=1&cid=mp&cv=sEUwvjl8K84.pl."}, // Thursday
                {"14.07", "https://www.google.com/maps/d/kml?forcekml=1&mid=15gRIrjBFGwj-aJXzkoB6AMIXTG4"}, // Friday
                {"15.07", "https://www.google.com/maps/d/kml?forcekml=1&mid=15gRIrjBFGwj-aJXzkoB6AMIXTG4"}, // Saturday
                {"16.07", "https://www.google.com/maps/d/kml?mid=1AawIPxHphPSojHFvtVoG3XEVW1I&forcekml=1&cid=mp&cv=sEUwvjl8K84.pl."}, // Sunday
                {"Utilities", "https://www.google.com/maps/d/kml?mid=1AawIPxHphPSojHFvtVoG3XEVW1I&forcekml=1&cid=mp&cv=sEUwvjl8K84.pl."} // Sunday

            };

        private BottomBar _bottomBar;
		private static string menuColor = "#3a3a3a";
		private static int menuItemCount = 5;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Map);

            MapFragment _mapFragment = FragmentManager.FindFragmentById(Resource.Id.map) as MapFragment;
            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeNormal)
                    .InvokeZoomControlsEnabled(false)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                _mapFragment = MapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, _mapFragment, "map");
                fragTx.Commit();
            }
            _mapFragment.GetMapAsync(this);

            //FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);

            _bottomBar = BottomBar.Attach(this, savedInstanceState);
			_bottomBar.SetItems(Resource.Menu.bottombar_menu);
			_bottomBar.SetOnMenuTabClickListener(this);

			// Setting colors for different tabs when there's more than three of them.
			// You can set colors for tabs in three different ways as shown below.

			for (int i = 0; i < menuItemCount; i++)
			{
				_bottomBar.MapColorForTab(i, menuColor);
			}
        }
        protected override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);
			// Necessary to restore the BottomBar's state, otherwise we would
			// lose the current tab on orientation change.
			_bottomBar.OnSaveInstanceState(outState);

		}

        public void OnMenuTabReSelected(int menuItemId)
        {
			if (menuItemId == Resource.Id.GalleryItem)
			{
				StartActivity(typeof(GalleryActivity));

			}
			else if (menuItemId == Resource.Id.ProgramItem)
			{
				StartActivity(typeof(MainActivity));

			}
			else if (menuItemId == Resource.Id.AboutItem)
			{
				StartActivity(typeof(AboutFestivalActivity));

			}
			else if (menuItemId == Resource.Id.SettingsItem)
			{
				StartActivity(typeof(SettingsActivity));

			}
			else if (menuItemId == Resource.Id.MapItem)
			{
				StartActivity(typeof(MapActivity));

			}
        }

        public void OnMenuTabSelected(int menuItemId)
        {
          
            
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            List<Event> _events = new List<Event>();

            List<MarkerOptions> placemarks = new List<MarkerOptions>();
            //wpisane w liste markerow
            _events = ReadEvents("13.07", _events);

            MarkerOptions _marker;

            foreach(var _mark in _events)
            {
                _marker = new MarkerOptions();
                _marker.SetTitle(_mark.Place);
                _marker.SetPosition(new LatLng(_mark.Longtitude, _mark.Latitude));
                placemarks.Add(_marker);
            }


            //obliczanie najlepszego widoku dla mapy
            double maxLat = _marker.Position.Latitude;
            double minLat = _marker.Position.Latitude;
            double maxLng = _marker.Position.Longitude;
            double minLng = _marker.Position.Longitude;
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


        private List<Event> ReadEvents(string mapId, List<Event> events)
        {
            Event actPL = new Event();
            Event actENG = new Event();

            //variable for spliting description
            string[] descpString;

            //variable for spliting coordinates
            string[] coordinates;

            using (XmlReader reader = XmlReader.Create(_maps[mapId]))
            {

                reader.MoveToContent();
                reader.ReadToDescendant("Placemark");

                do
                {
                    switch (reader.NodeType)
                    {

                        case XmlNodeType.CDATA:
                            descpString = reader.Value.Split(';');
                            // PL part
                            actPL.ActName = descpString[0];
                            actPL.TeatreName = descpString[1];
                            actPL.OriginCountry = descpString[2];
                            actPL.Description = descpString[3];
                            if (descpString[4] != null)
                                actPL.TimeEvent = DateTime.ParseExact(descpString[4], "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                            // ENG part
                            actENG.ActName = descpString[6];
                            actENG.TeatreName = descpString[7];
                            actENG.OriginCountry = descpString[8];
                            actENG.Description = descpString[9];
                            if (descpString[4] != null)
                                actENG.TimeEvent = DateTime.ParseExact(descpString[4], "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                            break;

                        case XmlNodeType.Element:

                            if (reader.Name == "name")
                            {
                                reader.Read();
                                actPL.Place = reader.Value;
                                actENG.Place = reader.Value;
                            }
                            else if (reader.Name == "coordinates")
                            {
                                reader.Read();
                                coordinates = reader.Value.Split(',');
                                actPL.Latitude = Convert.ToDouble(coordinates[0]);
                                actPL.Longtitude = Convert.ToDouble(coordinates[1]);
                                actENG.Latitude = Convert.ToDouble(coordinates[0]);
                                actENG.Longtitude = Convert.ToDouble(coordinates[1]);
                            }
                            break;
                    }

                    if (actPL.Description != null && actENG.Description != null)
                    {
                        events.Add(actPL);
                        events.Add(actENG);

                        actPL = new Event();
                        actENG = new Event();
                    }

                } while (reader.Read());

            }

            return events;
        }
    }
}
