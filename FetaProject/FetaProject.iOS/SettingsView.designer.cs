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

        void ReleaseDesignerOutlets ()
        {
            if (settingTitle != null) {
                settingTitle.Dispose ();
                settingTitle = null;
            }
        }
    }
}