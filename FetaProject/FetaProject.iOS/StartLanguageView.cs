using Foundation;
using System;
using UIKit;

namespace FetaProject.iOS
{
    public partial class StartLanguageView : UIViewController
	{

		public StartLanguageView (IntPtr handle) : base (handle)
        {
        }

		partial void PlButton_TouchUpInside(UIButton sender)
		{
			var userDefaults = NSUserDefaults.StandardUserDefaults;
			userDefaults.SetString("pl", "language");
			userDefaults.Synchronize(); // TODO: check on returned bool
			string value;
			value = "end";
			NSUserDefaults.StandardUserDefaults.SetString(value.ToString(), "Key");
			NSUserDefaults.StandardUserDefaults.Synchronize();

		}

		partial void EnButton_TouchUpInside(UIButton sender)
		{
			var userDefaults = NSUserDefaults.StandardUserDefaults;
			userDefaults.SetString("Base", "language");
			userDefaults.Synchronize(); // TODO: check on returned bool
			string value;
			value = "end";
			NSUserDefaults.StandardUserDefaults.SetString(value.ToString(), "Key");
			NSUserDefaults.StandardUserDefaults.Synchronize();
		}
	}
}