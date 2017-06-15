using Foundation;
using System;
using UIKit;

namespace FetaProject.iOS
{
    public partial class DetailProgramView : UIViewController
    {
		public Models.Event selectedEvent;
		public DetailProgramView (IntPtr handle) : base (handle)
        {
        }
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.NavigationItem.SetRightBarButtonItem(
			new UIBarButtonItem(UIImage.FromFile("Icons/map.png")
			, UIBarButtonItemStyle.Plain
			, (sender, args) =>
			{
				MapViewController map = Storyboard.InstantiateViewController("maps") as MapViewController;
				this.NavigationController.PushViewController(map, true);
				DisplayMapView displayMap = Storyboard.InstantiateViewController("map") as DisplayMapView;

				displayMap.a = selectedEvent.Place;
				displayMap.b = selectedEvent.Latitude;
				displayMap.c = selectedEvent.Longtitude;
			})
			, true);

		}
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			theatreNameLabel.Text = selectedEvent.TeatreName;
			actNameLabel.Text = selectedEvent.ActName;
			timeNameLabel.Text = selectedEvent.TimeEvent.ToString("HH:mm");
			descriptionTextView.Text = selectedEvent.Description;
			countryOriginLabel.Text = selectedEvent.OriginCountry;
		}
    }
}