using Foundation;
using System;
using UIKit;
using Google.Maps;

namespace FetaProject.iOS
{
	public partial class MapViewController : UIViewController
	{

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			map.Image = UIImage.FromBundle("Photo/Map.jpg");

			btnNotifications.TouchUpInside += (sender, e) =>
			{
				// create the notification
				var notification = new UILocalNotification();

				// set the fire date (the date time in which it will fire)
				notification.FireDate = NSDate.FromTimeIntervalSinceNow(30);

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

		}
	}
}