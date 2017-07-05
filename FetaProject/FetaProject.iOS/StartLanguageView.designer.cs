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
    [Register ("StartLanguageView")]
    partial class StartLanguageView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton enButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView languageview { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton plButton { get; set; }

        [Action ("EnButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void EnButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("PlButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PlButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (enButton != null) {
                enButton.Dispose ();
                enButton = null;
            }

            if (languageview != null) {
                languageview.Dispose ();
                languageview = null;
            }

            if (plButton != null) {
                plButton.Dispose ();
                plButton = null;
            }
        }
    }
}