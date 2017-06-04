using FetaProject.Models;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;


namespace FetaProject.iOS
{
    public partial class ProgramViewControler : UITableViewController
    {
        private readonly List<Event> _eventList;

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
    }
}