using Foundation;
using System;
using UIKit;

namespace FetaProject.iOS
{
    public partial class LanguageView : UIViewController
    {
        partial void UIButton1330_TouchUpInside(UIButton sender)
        {

            var userDefaults = NSUserDefaults.StandardUserDefaults;
            userDefaults.SetString("Base", "language");
            userDefaults.Synchronize(); // TODO: check on returned bool
        }

        partial void UIButton1329_TouchUpInside(UIButton sender)
        {
            var userDefaults = NSUserDefaults.StandardUserDefaults;
            userDefaults.SetString("pl", "language");
            userDefaults.Synchronize(); // TODO: check on returned bool
        }

        public LanguageView(IntPtr handle) : base(handle)
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