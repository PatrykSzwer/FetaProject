using Foundation;
using System;
using UIKit;

namespace FetaProject.iOS
{
    public partial class EventClassCell : UITableViewCell
    {
		private EventClass eventData;
		public EventClass EventData
		{
			get { return eventData; }
			set
			{
				eventData = value;
				TimeLabel.Text = eventData.TimeEvent.ToString("HH:mm");
				ActLabel.Text = eventData.ActName;
				TheatreLabel.Text = eventData.TeatreName;



			}
		}

		public EventClassCell (IntPtr handle) : base (handle)
        {
        }
    }
}