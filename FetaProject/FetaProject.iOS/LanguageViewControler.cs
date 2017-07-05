using Foundation;
using System;
using UIKit;
using FetaProject.iOS.LocalizationExtension;

namespace FetaProject.iOS
{
	public partial class LanguageViewControler : UIViewController
	{


		partial void ENButtonClick(UIButton sender)
		{
			var userDefaults = NSUserDefaults.StandardUserDefaults;
			userDefaults.SetString("Base", "language");
			userDefaults.Synchronize();

		}

		partial void PLButtonClick(UIButton sender)
		{
			var userDefaults = NSUserDefaults.StandardUserDefaults;
			userDefaults.SetString("pl", "language");
			userDefaults.Synchronize();

		}


		public LanguageViewControler(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

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
			View.SendSubviewToBack(uiImageView);

		}
		private void ReloadTabBarTitle()
		{
			
		}
	}
}