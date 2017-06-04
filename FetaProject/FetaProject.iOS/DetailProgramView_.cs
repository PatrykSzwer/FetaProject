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