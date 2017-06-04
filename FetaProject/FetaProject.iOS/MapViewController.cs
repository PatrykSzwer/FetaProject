using Foundation;
using System;
using UIKit;
using Google.Maps;
using CoreGraphics;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using CoreLocation;
using FetaProject.Models;


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
			//doc.Load("https://www.google.com/maps/d/kml?mid=1eABjtJfl-31WyggXycwIRsAI_d4&forcekml=1");
			//NIEDZIELA
			//var Map = "https://www.google.com/maps/d/kml?mid=1W2wGEBUezDja1qdDTG85fxicUNA&forcekml=1";


			//TestMap
			var map = "https://www.google.com/maps/d/kml?forcekml=1&mid=15gRIrjBFGwj-aJXzkoB6AMIXTG4";

			doc.Load(map);

			//lista elemtow z XML ktore nas interesuja
			XmlNodeList idNodes = doc.GetElementsByTagName("Placemark");
			//Marker
			Marker marker = new Marker();
			List<Marker> placemarks = new List<Marker>();
			//wpisane w liste markerow
			placemarks = ReadMarkers(idNodes, placemarks, marker);

			//zbranie info o eventach
			List<Event> events = new List<Event>();
			events = ReadEvents(map, events);

			//debug console write of list
			Console.WriteLine("Lista eventow:");
			foreach (var cos in events)
			{
				Console.WriteLine(cos.ActName + "," + cos.TeatreName + "," + cos.OriginCountry + "," + cos.Description + "," + cos.TimeEvent);
			};

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

				if (marker.Position.Latitude > 0  &&  marker.Title != null)
				{
					

					placemarks.Add(marker);
					marker = new Marker();

				}

			}
			return placemarks;
		}

		private List<Event> ReadEvents(string map, List<Event> events)
		{
			Event actPL = new Event();
			Event actENG = new Event();

			//zmienna potrzebna do rozdzielania opisu
			string[] descpString;

			// zmienna przechowujaca miejsce spektaklu np. A, B, ...
			string eventPlace = String.Empty;

			using (XmlReader reader = XmlReader.Create(map))
			{

				reader.MoveToContent();
				reader.ReadToDescendant("Placemark");

				do
				{
					switch (reader.NodeType)
					{

						case XmlNodeType.CDATA:
							Console.Write(reader.Value);
							descpString = reader.Value.Split(';');
							// PL part
							actPL.ActName = descpString[0];
							actPL.TeatreName = descpString[1];
							actPL.OriginCountry = descpString[2];
							actPL.Description = descpString[3];
							if (descpString[4] !=null)
							actPL.TimeEvent = DateTime.ParseExact(descpString[4], "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
							//Console.WriteLine("Data wydarzenia:{0}",descpString[4]);

							// ENG part
							actENG.ActName = descpString[6];
							actENG.TeatreName = descpString[7];
							actENG.OriginCountry = descpString[8];
							actENG.Description = descpString[9];
							if (descpString[4] != null)
								actENG.TimeEvent = DateTime.ParseExact(descpString[4], "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
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