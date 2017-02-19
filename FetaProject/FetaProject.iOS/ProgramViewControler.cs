using Foundation;
using System;
using System.Linq;
using UIKit;
using System.Collections.Generic;


namespace FetaProject.iOS
{
	public partial class ProgramViewControler : UITableViewController
	{
		public DateTime[] test = new DateTime[]{

			new DateTime(2017, 7, 13),
			new DateTime(2017, 7, 14),
			new DateTime(2017, 7, 15),
			new DateTime(2017, 7, 16)

		};
		List<EventClass> EventList;
		public ProgramViewControler(IntPtr handle) : base(handle)
		{
			
			EventList = new List<EventClass>();

			EventList.Add(new EventClass()
			{
				TeatreName = "FETA",
				ActName = "Te białe kwiaty",
				TimeEvent = new DateTime(2017, 7, 15, 15, 30, 0)
			});
			EventList.Add(new EventClass()
			{
				TeatreName = "Titanic",
				ActName = "Test działania",
				TimeEvent = new DateTime(2017, 7, 14, 22, 30, 0)
			});
			EventList.Add(new EventClass()
			{
				TeatreName = "Titanic",
				ActName = "Test działania",
				TimeEvent = new DateTime(2017, 7, 13, 22, 30, 0)
			});
			EventList.Add(new EventClass()
			{
				TeatreName = "Titanic",
				ActName = "Test działania",
				TimeEvent = new DateTime(2017, 7, 16, 22, 30, 0)
			});
			EventList.Add(new EventClass()
			{
				TeatreName = "FETA",
				ActName = "Te białe kwiaty",
				TimeEvent = new DateTime(2017, 7, 15, 15, 30, 0)
			});
			EventList.Add(new EventClass()
			{
				TeatreName = "Titanic",
				ActName = "Test działania",
				TimeEvent = new DateTime(2017, 7, 14, 22, 30, 0)
			});
			EventList.Add(new EventClass()
			{
				TeatreName = "Titanic",
				ActName = "Test działania",
				TimeEvent = new DateTime(2017, 7, 13, 22, 30, 0)
			});
			EventList.Add(new EventClass()
			{
				TeatreName = "Titanic",
				ActName = "Test działania",
				TimeEvent = new DateTime(2017, 7, 16, 22, 30, 0)
			});
			EventList.Add(new EventClass()
			{
				TeatreName = "FETA",
				ActName = "Te białe kwiaty",
				TimeEvent = new DateTime(2017, 7, 15, 15, 30, 0)
			});
			EventList.Add(new EventClass()
			{
				TeatreName = "Titanic",
				ActName = "Test działania",
				TimeEvent = new DateTime(2017, 7, 14, 22, 30, 0)
			});
			EventList.Add(new EventClass()
			{
				TeatreName = "Titanic",
				ActName = "Test działania",
				TimeEvent = new DateTime(2017, 7, 13, 22, 30, 0)
			});
			EventList.Add(new EventClass()
			{
				TeatreName = "Titanic",
				ActName = "Test działania",
				TimeEvent = new DateTime(2017, 7, 16, 22, 30, 0)
			});
			EventList.Add(new EventClass()
			{
				TeatreName = "FETA",
				ActName = "Te białe kwiaty",
				TimeEvent = new DateTime(2017, 7, 15, 15, 30, 0)
			});
			EventList.Add(new EventClass()
			{
				TeatreName = "Titanic",
				ActName = "Test działania",
				TimeEvent = new DateTime(2017, 7, 15, 22, 30, 0)
			});
			EventList.Add(new EventClass()
			{
				TeatreName = "Titanic",
				ActName = "Test działania",
				TimeEvent = new DateTime(2017, 7, 15, 22, 30, 0)
			});
			EventList.Add(new EventClass()
			{
				TeatreName = "Titanic",
				ActName = "Test działania",
				TimeEvent = new DateTime(2017, 7, 15, 22, 30, 0)
			});

		}
		public override nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}
		public override nint RowsInSection(UITableView tableView, nint section)
		{
			var selectedDate = test[SegmentDayControl.SelectedSegment].Date.Day;
			return EventList.Where(x => x.TimeEvent.Day==selectedDate).Count();
		}
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			SegmentDayControl.ValueChanged += (sender, e) => TableEvent.ReloadData();
			var cell = tableView.DequeueReusableCell("ShowEvent") as EventClassCell;
			var selectedDate = test[SegmentDayControl.SelectedSegment].Date.Day;
			var theatreEvents = EventList.Where(x => x.TimeEvent.Day == selectedDate).ToArray();

			var data = theatreEvents[indexPath.Row];

			cell.EventData = data;


			return cell;
		}
		private void SegmentChange(object sender, EventArgs e, int row, EventClassCell cell)
		{
			TableEvent.ReloadData();


		}
	}

}