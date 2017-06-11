using FetaProject.Models;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UIKit;


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
        public override void ViewDidLoad()
        {
			base.ViewDidLoad();
            SegmentDayControl.ValueChanged += (sender, e) => TableEvent.ReloadData();


			//TestMap
			var map = "https://www.google.com/maps/d/kml?forcekml=1&mid=15gRIrjBFGwj-aJXzkoB6AMIXTG4";
			//zbranie info o eventach
			List<Event> events = new List<Event>();
			List<Event> eventsENG = new List<Event>();
			events = ReadEvents(map, events);

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

		private List<Event> ReadEvents(string map, List<Event> events)
		{
			Event actPL = new Event();
			Event actENG = new Event();

			//variable for spliting description
			string[] descpString;

			//variable for spliting coordinates
			string[] coordinates;

			using (XmlReader reader = XmlReader.Create(map))
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