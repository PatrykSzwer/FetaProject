using Foundation;
using System;
using UIKit;

namespace FetaProject.iOS
{
    public partial class SettingsView : UIViewController
    {
		partial void TestButton_TouchUpInside(UIButton sender)
		{
			
		}

        public SettingsView (IntPtr handle) : base (handle)
        {
			//UIButton testButton1 = new UIButton();



        }
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//testButton.SetTitle(lang.LanguageBundle.LocalizedString("Test", "optional"),UIControlState.Normal) ;

			testlabel.Text = "Test".Translate();
		}
    }
}