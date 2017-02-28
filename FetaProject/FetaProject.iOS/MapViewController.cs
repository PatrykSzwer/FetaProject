using Foundation;
using System;
using UIKit;
using Google.Maps;
using CoreGraphics;
using System.Xml;
using System.Collections.Generic;
using CoreLocation;


namespace FetaProject.iOS
{
    public partial class MapViewController : UIViewController
    {

		private MapView mapView;
		NetworkStatus internetStatus = Reachability.InternetConnectionStatus();

		public MapViewController (IntPtr handle) : base (handle)
        {
        }
		public override void LoadView()
		{
			base.LoadView();


		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			if (!Reachability.IsHostReachable("http://google.com"))
			{
				map.Image = UIImage.FromBundle("Photo/Map.jpg");
			}
			else
			{
				OnMapReady();
				View = mapView;	
			}


		}
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			//mapView.StartRendering();
		}

		public override void ViewWillDisappear(bool animated)
		{
			//mapView.StopRendering();
			base.ViewWillDisappear(animated);
		}
		public void OnMapReady()
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
			Console.WriteLine(location);			//CameraPosition. mapView = CameraPosition.InvokeBuilder();
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
				Console.WriteLine(iMarker);

			}


			//Opcje mapy i update'y
			//trzeba bedzie dodac obsluge nawigacji
			//mapView.Settings.ZoomGestures = true;// google.UiSettings.ZoomControlsEnabled = true;
			//mapView.Settings.AllowScrollGesturesDuringRotateOrZoom = true;
			//googleMap.UiSettings.CompassEnabled = true;
			//googleMap.MoveCamera(.ZoomIn());
			//googleMap.MoveCamera(cameraUpdate);
				
		
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
				else if (node.Name == "description")
				{
					marker.Snippet = node.FirstChild.Value;
				}
				else
				{
					ReadMarkers(node.ChildNodes, placemarks, marker);
				}

				if (marker.Position.Latitude > 0  &&  marker.Title != null)
				{
					

					placemarks.Add(marker);
					marker = new Marker();

				}

			}
			return placemarks;
		}
    }
}