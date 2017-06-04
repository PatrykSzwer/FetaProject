using FetaProject.iOS.LocalizationExtension;
using System;
using UIKit;

namespace FetaProject.iOS
{
    public partial class SettingsView : UIViewController
    {
        partial void TestButton_TouchUpInside(UIButton sender)
        {

        }

        public SettingsView(IntPtr handle) : base(handle)
        {
            //UIButton testButton1 = new UIButton();
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            testButton.SetTitle("Language".Translate(),UIControlState.Normal);
			settingTitle.Title = "Settings".Translate();
            
        }
    }
}