using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace FetaProject.iOS
{
    public partial class MapViewController : UIViewController
    {
        private readonly DisplayMapView _mapView;
        private readonly Dictionary<int, string> _eventsDayMapper = new Dictionary<int, string>
        {
            {0, "13.07"},
            {1, "14.07"},
            {2, "15.07"},
            {3, "16.07"}
        };


		public override void ViewDidLoad()
		{
			map.Image = UIImage.FromBundle("Photo/Map.jpg");
			SelectDay.ValueChanged += SegmentChange;

			btnNotifications.TouchUpInside += (sender, e) =>
			{
				// create the notification
				var notification = new UILocalNotification();

				// set the fire date (the date time in which it will fire)
				notification.FireDate = NSDate.FromTimeIntervalSinceNow(5);

				// configure the alert
				notification.AlertAction = "View Alert";
				notification.AlertBody = "Your one minute alert has fired!";

				// modify the badge
				notification.ApplicationIconBadgeNumber = 1;

				// set the sound to be the default sound
				notification.SoundName = UILocalNotification.DefaultSoundName;

				// schedule it
				UIApplication.SharedApplication.ScheduleLocalNotification(notification);
			};

		}


        public MapViewController(IntPtr handle) : base(handle)
        {
            var storyboard = UIStoryboard.FromName("Main", null);
            _mapView = storyboard.InstantiateViewController("map") as DisplayMapView;
        }

        private void SegmentChange(object sender, EventArgs e)
        {
            var selectedSegmentId = (int)(sender as UISegmentedControl).SelectedSegment;
            _mapView.Test(_eventsDayMapper[selectedSegmentId]);
        }
    }
}