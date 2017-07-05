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
			UIGraphics.BeginImageContext(View.Frame.Size);
			UIImage.FromBundle("bg.png").Draw(View.Bounds);
			var bgImage = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();

			var uiImageView = new UIImageView(View.Frame);
			uiImageView.Image = bgImage;
			uiImageView.ContentMode = UIViewContentMode.Center;
			View.AddSubview(uiImageView);

			//descriptionTextView.BackgroundColor = UIColor.Clear;
			View.SendSubviewToBack(infoBackground);
			View.SendSubviewToBack(uiImageView);
			this.NavigationItem.SetRightBarButtonItem(
			new UIBarButtonItem(UIImage.FromFile("Icons/map.png")
			, UIBarButtonItemStyle.Plain
			, (sender, args) =>
			{
				MapViewController map = Storyboard.InstantiateViewController("maps") as MapViewController;
				this.NavigationController.PushViewController(map, true);


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