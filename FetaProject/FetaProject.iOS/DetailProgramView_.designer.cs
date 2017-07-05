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
    [Register ("DetailProgramView")]
    partial class DetailProgramView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel actNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel countryOriginLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView descriptionTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView infoBackground { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel theatreNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel timeNameLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (actNameLabel != null) {
                actNameLabel.Dispose ();
                actNameLabel = null;
            }

            if (countryOriginLabel != null) {
                countryOriginLabel.Dispose ();
                countryOriginLabel = null;
            }

            if (descriptionTextView != null) {
                descriptionTextView.Dispose ();
                descriptionTextView = null;
            }

            if (infoBackground != null) {
                infoBackground.Dispose ();
                infoBackground = null;
            }

            if (theatreNameLabel != null) {
                theatreNameLabel.Dispose ();
                theatreNameLabel = null;
            }

            if (timeNameLabel != null) {
                timeNameLabel.Dispose ();
                timeNameLabel = null;
            }
        }
    }
}