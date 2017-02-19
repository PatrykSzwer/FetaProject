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
    [Register ("ProgramViewControler")]
    partial class ProgramViewControler
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl SegmentDayControl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TableEvent { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (SegmentDayControl != null) {
                SegmentDayControl.Dispose ();
                SegmentDayControl = null;
            }

            if (TableEvent != null) {
                TableEvent.Dispose ();
                TableEvent = null;
            }
        }
    }
}