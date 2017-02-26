using Foundation;
using System;
using UIKit;

namespace FetaProject.iOS
{
    public partial class LanguageView : UIViewController
    {
		



		partial void UIButton1330_TouchUpInside(UIButton sender)
		{
			
			var path1 = NSBundle.MainBundle.PathForResource("pl", "lproj");
			BundleManager language = new BundleManager();
			language.LanguageBundle = new NSBundle(path1);;


		}

		partial void UIButton1329_TouchUpInside(UIButton sender)
		{
			
			var path2 = NSBundle.MainBundle.PathForResource("Base", "lproj");
			BundleManager language = new BundleManager();
			language.LanguageBundle = new NSBundle(path2);

			//BundleManager.languageBundle = languageBundle;


		}

		public LanguageView (IntPtr handle) : base (handle)
        {
        }
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);



		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


		}
    }
}