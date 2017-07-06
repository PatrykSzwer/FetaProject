// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FetaProject.iOS
{
    [Register ("LanguageViewControler")]
    partial class LanguageViewControler
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton plButton { get; set; }

        [Action ("ENButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ENButtonClick (UIKit.UIButton sender);

        [Action ("PLButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PLButtonClick (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (plButton != null) {
                plButton.Dispose ();
                plButton = null;
            }
        }
    }
}