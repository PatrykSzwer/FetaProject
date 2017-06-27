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
    [Register ("PosterView")]
    partial class PosterView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView aboutFestivalTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel titleAboutFestiwal { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (aboutFestivalTextView != null) {
                aboutFestivalTextView.Dispose ();
                aboutFestivalTextView = null;
            }

            if (titleAboutFestiwal != null) {
                titleAboutFestiwal.Dispose ();
                titleAboutFestiwal = null;
            }
        }
    }
}