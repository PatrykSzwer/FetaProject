using Foundation;
using System;
using UIKit;
using FetaProject.iOS.LocalizationExtension;


namespace FetaProject.iOS
{
	public partial class TutorialView : UIViewController
	{
		
		int imageCounter = 0;
		string[] arrayOfImage = { "TutorialPhoto/Tutorial_1.png", "TutorialPhoto/Tutorial_2.png", "TutorialPhoto/Tutorial_3.png", "TutorialPhoto/Tutorial_4.png", "TutorialPhoto/Tutorial_5.png", "TutorialPhoto/Tutorial_6.png", "TutorialPhoto/Tutorial_7.png" };

		public TutorialView(IntPtr handle) : base(handle)
		{
		}

		partial void ShowLabel(UISwitch sender)
		{
			if (tutorialAgainSwitch.On)
			{
				dontShowAgainLabel.Hidden = false;
			}
			else
			{
				dontShowAgainLabel.Hidden = true;
			}

		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			tutorialImage.Image = UIImage.FromBundle(arrayOfImage[imageCounter]);
			PrevButton.Hidden = true;
			skipButton.SetTitle("skip".Translate(), UIControlState.Normal);
			dontShowAgainLabel.Text = "Not_Show_Tutoraial".Translate();

		}


		partial void NextButton_TouchUpInside(UIButton sender)
		{
			
			if(imageCounter !=arrayOfImage.Length - 1)
			{
				PrevButton.Hidden = false;
				imageCounter++;
			}
			tutorialImage.Image = UIImage.FromBundle(arrayOfImage[imageCounter]);
			if (imageCounter == arrayOfImage.Length -1)
			{
				nextButton.Hidden = true;
				skipButton.SetTitle("End".Translate(), UIControlState.Normal);
			}

		}

		partial void PrevButton_TouchUpInside(UIButton sender)
		{
			skipButton.SetTitle("skip".Translate(), UIControlState.Normal);

			if(imageCounter != 0)
			{
				nextButton.Hidden = false;
				imageCounter--;
			}
		
			tutorialImage.Image = UIImage.FromBundle(arrayOfImage[imageCounter]);
			if(imageCounter == 0)
			{
				PrevButton.Hidden = true;
			}
		}

		partial void SkipButton_TouchUpInside(UIButton sender)
		{
			string value;

			if (tutorialAgainSwitch.On)
			{
				 value = "no";
				NSUserDefaults.StandardUserDefaults.SetString(value.ToString(), "Key");
				NSUserDefaults.StandardUserDefaults.Synchronize();
			}
			else
			{ 
				value = "yes";
				NSUserDefaults.StandardUserDefaults.SetString(value.ToString(), "Key");
				NSUserDefaults.StandardUserDefaults.Synchronize();
			}
			
		}
	}
}