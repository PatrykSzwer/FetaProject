using Foundation;
using System;
using UIKit;
using FetaProject.iOS.LocalizationExtension;

namespace FetaProject.iOS
{
    public partial class PosterView : UIViewController
    {
        public PosterView (IntPtr handle) : base (handle)
        {
        }
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			titleAboutFestiwal.Text = "PosterTitle".Translate();
			aboutFestivalTextView.BackgroundColor = UIColor.Clear;

		}
    }
}