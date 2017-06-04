using Foundation;
using System;
using UIKit;

namespace FetaProject.iOS
{
	
    public partial class GalleryView : UIViewController
    {
		int imageCounter = 0;
		string[] arrayOfImage = { "Photo/FETA_2001.jpg", "Photo/FETA_2013_1.jpg", "Photo/FETA_2013_2.jpg", "Photo/FETA_2015_1.jpg", "Photo/FETA_2015_2.jpeg", "Photo/FETA_2014.jpg", "Photo/poster.jpg" };
        public GalleryView (IntPtr handle) : base (handle)
        {
		TabBarItem.Title = "aaa";

		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();



			imageView.Image = UIImage.FromBundle(arrayOfImage[imageCounter]); 
		}

		partial void UIButton2799_TouchUpInside(UIButton sender)
		{
			if (imageCounter == arrayOfImage.Length -1)
			{
				imageCounter = 0;
			}
			else
			{
				imageCounter++;
			}
			imageView.Image = UIImage.FromBundle(arrayOfImage[imageCounter]);
		}



		partial void UIButton2798_TouchUpInside(UIButton sender)
		{
			if (imageCounter == 0)
			{
				imageCounter = arrayOfImage.Length-1;
			}
			else
			{
				imageCounter--;
			}
			imageView.Image = UIImage.FromBundle(arrayOfImage[imageCounter]);
		}
	}
}