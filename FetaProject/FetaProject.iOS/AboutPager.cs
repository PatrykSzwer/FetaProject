using Foundation;
using System;
using UIKit;

namespace FetaProject.iOS
{
    public partial class AboutPager : UIPageViewController
    {
        public AboutPager (IntPtr handle) : base (handle)
        {
        }
		public nint PageNumber { get; set; } = 0;



		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Initialize
			PageView.Pages = 6;
			ShowCat();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}





		private void ShowCat()
		{
			PageView.CurrentPage = PageNumber;
			Console.WriteLine(" work");
		}

    }
}