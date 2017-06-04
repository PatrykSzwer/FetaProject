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
			posterTitleLabel.Text = "PosterTitle".Translate();
		}
    }
}