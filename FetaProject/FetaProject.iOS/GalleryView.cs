using Foundation;
using System;
using UIKit;

namespace FetaProject.iOS
{
    public partial class GalleryView : UIViewController
    {
		string[] arrayOfImage = { "Photo/FETA_2001.jpg", "Photo/FETA_2013_1.jpg", "Photo/FETA_2013_2.jpg", "Photo/FETA_2015_1.jpg", "Photo/FETA_2015_2.jpg", "Photo/FETA_2014.jpg", "Photo/poster.jpg" };
        public GalleryView (IntPtr handle) : base (handle)
        {
        }
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			imageView.Image = UIImage.FromBundle("Photo/FETA_2001.jpg");
			Swipe = new UISwipeGestureRecognizer(ChangePhoto);



			Console.WriteLine();
		
			//imageView.Frame = new CoreGraphics.CGRect(10, 10, imageView.Image.CGImage.Width, imageView.Image.CGImage.Height);
		}
		private void ChangePhoto()
		{
			Console.WriteLine("work");
		}
    }
}