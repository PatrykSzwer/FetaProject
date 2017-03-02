using FetaProject.Models;
using System;
using UIKit;

namespace FetaProject.iOS
{
    public partial class EventClassCell : UITableViewCell
    {
        private Event _eventData;
        public Event EventData
        {
            get
            {
                return _eventData;
            }
            set
            {
                _eventData = value;
                TimeLabel.Text = _eventData.TimeEvent.ToString("HH:mm");
                ActLabel.Text = _eventData.ActName;
                TheatreLabel.Text = _eventData.TeatreName;
            }
        }

        public EventClassCell(IntPtr handle) : base(handle)
        {
        }
    }
}