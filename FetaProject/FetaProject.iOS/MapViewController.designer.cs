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
    [Register ("MapViewController")]
    partial class MapViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView map { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem mapButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton OthersButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl SelectDay { get; set; }

        [Action ("PrevPhoto_TouchUpInside")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PrevPhoto_TouchUpInside ();

        [Action ("PrevPhoto_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PrevPhoto_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (map != null) {
                map.Dispose ();
                map = null;
            }

            if (mapButton != null) {
                mapButton.Dispose ();
                mapButton = null;
            }

            if (OthersButton != null) {
                OthersButton.Dispose ();
                OthersButton = null;
            }

            if (SelectDay != null) {
                SelectDay.Dispose ();
                SelectDay = null;
            }
        }
    }
}