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
    [Register ("TutorialView")]
    partial class TutorialView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel dontShowAgainLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton nextButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PrevButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton skipButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch tutorialAgainSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView tutorialImage { get; set; }

        [Action ("NextButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void NextButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("PrevButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PrevButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("ShowLabel:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ShowLabel (UIKit.UISwitch sender);

        [Action ("SkipButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SkipButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (dontShowAgainLabel != null) {
                dontShowAgainLabel.Dispose ();
                dontShowAgainLabel = null;
            }

            if (nextButton != null) {
                nextButton.Dispose ();
                nextButton = null;
            }

            if (PrevButton != null) {
                PrevButton.Dispose ();
                PrevButton = null;
            }

            if (skipButton != null) {
                skipButton.Dispose ();
                skipButton = null;
            }

            if (tutorialAgainSwitch != null) {
                tutorialAgainSwitch.Dispose ();
                tutorialAgainSwitch = null;
            }

            if (tutorialImage != null) {
                tutorialImage.Dispose ();
                tutorialImage = null;
            }
        }
    }
}