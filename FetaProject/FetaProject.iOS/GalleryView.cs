using Foundation;
using System;
using UIKit;


namespace FetaProject.iOS
{
	
    public partial class GalleryView : UIViewController
    {


		int imageCounter = 0;
		string[] arrayOfImage = { 
			"Photo/1.jpg",
			"Photo/2.jpg",
			"Photo/3.jpg",
			"Photo/4.jpg",
			"Photo/5.jpg",
			"Photo/6.jpg",
			"Photo/8.jpg",
			"Photo/9.jpg",
			"Photo/10.jpg",
			"Photo/11.jpg",
			"Photo/12.jpg",
			"Photo/13.jpg",
			"Photo/14.jpg",
			"Photo/15.jpg",
			"Photo/16.jpg",
			"Photo/17.jpg",
			"Photo/18.jpg",
			"Photo/19.jpg",
			"Photo/20.jpg",
			"Photo/21.jpg",
			"Photo/22́.jpg",
			"Photo/22.jpg",
			"Photo/23.jpg",
			"Photo/24.jpg",
			"Photo/25.jpg",
			"Photo/26.jpg"
		};
		
        public GalleryView (IntPtr handle) : base (handle)
        {


		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			UISwipeGestureRecognizer recognizerLeft = new UISwipeGestureRecognizer(UpdateLeft);


			recognizerLeft.Direction = UISwipeGestureRecognizerDirection.Left;

			UISwipeGestureRecognizer recognizerRight = new UISwipeGestureRecognizer(UpdateRight);
			recognizerRight.Direction = UISwipeGestureRecognizerDirection.Right;

    		View.AddGestureRecognizer (recognizerRight);
			View.AddGestureRecognizer(recognizerLeft);
            PinImage imagePath = new PinImage();


			imageView.Image = UIImage.FromBundle(arrayOfImage[imageCounter]);
			UIGraphics.BeginImageContext(View.Frame.Size);
			UIImage.FromBundle("bg.png").Draw(View.Bounds);
			var bgImage = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();

			var uiImageView = new UIImageView(View.Frame);
			uiImageView.Image = bgImage;
			uiImageView.ContentMode = UIViewContentMode.Center;
			View.AddSubview(uiImageView);
			View.SendSubviewToBack(uiImageView);
         

			//imageView.Image
		}

		private void UpdateLeft()
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
		private void UpdateRight()
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
	}
}