// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FetaProject.iOS
{
    [Register ("SettingsView")]
    partial class SettingsView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem settingTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton testButton { get; set; }

        [Action ("TestButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TestButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (settingTitle != null) {
                settingTitle.Dispose ();
                settingTitle = null;
            }

            if (testButton != null) {
                testButton.Dispose ();
                testButton = null;
            }
        }
    }
}