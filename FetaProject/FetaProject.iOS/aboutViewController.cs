using Foundation;
using System;
using UIKit;
using System.IO;
using System.Drawing;

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

		/*	webView = new UIWebView(View.Bounds);
			View.AddSubview(webView);

            var fileName =  "FETA 2017 gazeta druk.pdf";
            Console.WriteLine(fileName);

            string localDocUrl = Path.Combine(NSBundle.MainBundle.BundlePath, fileName) ;
			webView.LoadRequest(new NSUrlRequest(new NSUrl(localDocUrl, false)));
			webView.ScalesPageToFit = true;


           /* string path = Environment.GetFolderPath(Environment.SpecialFolder.Resources);
			string filePath = Path.Combine(path, "PDF/gazeta.pdf");
			var viewer = UIDocumentInteractionController.FromUrl(NSUrl.FromFilename(filePath));
			viewer.PresentOpenInMenu(new RectangleF(0, 0, 320, 320), this.View, true);*/

        }
    }
}