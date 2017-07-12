using Foundation;
using System;
using UIKit;
using System.IO;

namespace FetaProject.iOS
{
    public partial class aboutViewController : UIViewController
    {
        public aboutViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			webView = new UIWebView(View.Bounds);
			View.AddSubview(webView);

			string fileName = "FETAGazeta.pdf"; // remember case-sensitive
			string localDocUrl = Path.Combine(NSBundle.MainBundle.BundlePath, fileName);
			webView.LoadRequest(new NSUrlRequest(new NSUrl(localDocUrl, false)));
			webView.ScalesPageToFit = true;
        }
    }
}