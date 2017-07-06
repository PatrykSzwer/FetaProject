using Foundation;
using System;
using UIKit;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace FetaProject.iOS
{
    
    public partial class AboutPager : UIPageViewController
    {
        public nint PageNumber { get; private set; }

        public AboutPager (IntPtr handle) : base (handle)
        {
        }
    


	    public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			
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