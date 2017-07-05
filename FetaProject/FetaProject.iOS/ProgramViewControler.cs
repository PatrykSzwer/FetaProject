using FetaProject.Models;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UIKit;
using System.Reflection;
using System.IO;

namespace FetaProject.iOS
{
    public partial class ProgramViewControler : UITableViewController
    {
        private List<Event> _eventList;

        private readonly DateTime[] _eventsDates = {
			new DateTime(2017, 7, 13),
            new DateTime(2017, 7, 14),
            new DateTime(2017, 7, 15),
            new DateTime(2017, 7, 16)
        };

		Event[] theatreEvents;

		private readonly Dictionary<int, string> _eventsDay = new Dictionary<int, string>
		{
			{0, "13.07"},
			{1, "14.07"},
			{2, "15.07"},
			{3, "16.07"}
		};

		public string _dayId = "13.07";

		private readonly Dictionary<string, string> _days = new Dictionary<string, string>
			{
				{"13.07", "FetaProject.iOS.Resources.Maps.dayMap1.kml"}, // Thursday
                {"14.07", "FetaProject.iOS.Resources.Maps.dayMap2.kml"}, // Friday
                {"15.07", "FetaProject.iOS.Resources.Maps.dayMap3.kml"}, // Saturday
                {"16.07", "FetaProject.iOS.Resources.Maps.dayMap4.kml"} // Sunday

            };

        public override void ViewDidLoad()
        {
			base.ViewDidLoad();

            if(DateTime.Today <= _eventsDates[0] || DateTime.Today > _eventsDates[3])
            {
                SegmentDayControl.SelectedSegment = 0;
                LoadDay("13.07");            }
            else if(DateTime.Today == _eventsDates[1])
            {
                SegmentDayControl.SelectedSegment = 1;
                LoadDay("14.07");
            }
            else if(DateTime.Today == _eventsDates[2])
            {
                SegmentDayControl.SelectedSegment = 2;
                LoadDay("14.07");
            }
            else
            {
                SegmentDayControl.SelectedSegment = 3;
                LoadDay("14.07");
            }

            SegmentDayControl.ValueChanged += SegmentChange;


        }

		private void SegmentChange(object sender, EventArgs e)
		{
			var selectedSegmentId = (int)(sender as UISegmentedControl).SelectedSegment;
			_dayId = _eventsDay[selectedSegmentId];
			LoadDay(_dayId);
		}


        public void LoadDay(String dayId)
        {
			

			//zbranie info o eventach
			List<Event> events = new List<Event>();
			List<Event> eventsENG = new List<Event>();
            events = ReadEvents(dayId, events);

			//split list of events by language
			for (var i = 1; i < events.Count; i++)
			{
				eventsENG.Add(events[i]);
				events.Remove(events[i]);
			}

			// choose list for specific language
			var userDefaults = NSUserDefaults.StandardUserDefaults;
			var selectedLng = userDefaults.ValueForKey((Foundation.NSString)"language");

			if (selectedLng.ToString() == "pl")
			{
				_eventList = events;
			}
			else if (selectedLng.ToString() == "Base")
			{
				_eventList = eventsENG;
			}

            TableEvent.ReloadData();
        }

        public ProgramViewControler(IntPtr handle) : base(handle)
        {
            _eventList = EventsManager.EventsManager.GetEvents().ToList();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            var selectedDate = _eventsDates[SegmentDayControl.SelectedSegment].Date.Day;
            return _eventList.Count(x => x.TimeEvent.Day == selectedDate);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
			
            var cell = tableView.DequeueReusableCell("ShowEvent") as EventClassCell;
            var selectedDate = _eventsDates[SegmentDayControl.SelectedSegment].Date.Day;
            theatreEvents = _eventList.Where(x => x.TimeEvent.Day == selectedDate).ToArray();

            var data = theatreEvents[indexPath.Row];

            cell.EventData = data;

            return cell;
        }

        // Unused method? Should be used key word "override" or deleted?
        private void SegmentChange(object sender, EventArgs e, int row, EventClassCell cell)
        {
            TableEvent.ReloadData();
        }
		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			
			if (segue.Identifier == "EventDetail")
			{
				var detileController = segue.DestinationViewController as DetailProgramView;

				if (detileController != null)
				{
					var rowPath = TableView.IndexPathForSelectedRow;
					var selectedData = theatreEvents[rowPath.Row];
					detileController.selectedEvent = selectedData;
				}
			}
		}

		private List<Event> ReadEvents(string dayId, List<Event> events)
		{
			Event actPL = new Event();
			Event actENG = new Event();

			//variable for spliting description
			string[] descpString;

			//variable for spliting coordinates
			string[] coordinates;

            DateTime temp;

			Assembly _assembly = Assembly.GetExecutingAssembly();
            Stream _fileStream = _assembly.GetManifestResourceStream(_days[dayId]);

            using (XmlReader reader = XmlReader.Create(_fileStream))
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

                            if (DateTime.TryParse(descpString[4], out temp))
                                actPL.TimeEvent = temp;

							// ENG part
							actENG.ActName = descpString[6];
							actENG.TeatreName = descpString[7];
							actENG.OriginCountry = descpString[8];
							actENG.Description = descpString[9];
							if (DateTime.TryParse(descpString[4], out temp))
								actENG.TimeEvent = temp;
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
								//actPL.Latitude = Convert.ToDouble(coordinates[0]);
								//actPL.Longtitude = Convert.ToDouble(coordinates[1]);
								//actENG.Latitude = Convert.ToDouble(coordinates[0]);
								//actENG.Longtitude = Convert.ToDouble(coordinates[1]);
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
		private void daySegmentSeter()
		{
			
		}
    }
}























