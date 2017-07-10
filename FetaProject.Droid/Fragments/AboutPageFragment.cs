
using Android.App;
using Android.Webkit;
using FetaProject.Droid.Fragments.Base;

namespace FetaProject.Droid.Fragments
{
    public class AboutPageFragment : BaseSlidePageFragment
    {
        private string _pdfFilePath = "file:///android_asset/paper.pdf";
        private WebView _webView;
        private string _pdfURL = @"http://sal.aalto.fi/publications/pdf-files/eluu11_public.pdf";

        public AboutPageFragment(Activity context) : base(Resource.Layout.fragment_screen_slide_page_about)
        {
        }

        public override void ViewInitialization()
        {
            _webView = FragmentView.FindViewById<WebView>(Resource.Id.webViewForPdf);
            _webView.Settings.JavaScriptEnabled = true;
            _webView.Settings.AllowFileAccessFromFileURLs = true;
            _webView.Settings.AllowUniversalAccessFromFileURLs = true;
            _webView.Settings.BuiltInZoomControls = true;
            _webView.SetWebChromeClient(new WebChromeClient());
            _webView.LoadUrl("file:///android_asset/pdfviewer/index.html?file=" + _pdfFilePath);

            //DownloadPDFDocument();
            //OpenPdfDocument();
        }
        /*
        private void DownloadPDFDocument()
        {
            //AndHUD.Shared.Show(this, "Downloading PDF\nPlease Wait ..", -1, MaskType.Clear);

            _pdfPath = _documentsPath + "/PDFView";
            _pdfFilePath = Path.Combine(_pdfPath, _pdfFileName);

            // Check if the PDFDirectory Exists
            if (!Directory.Exists(_pdfPath))
            {
                Directory.CreateDirectory(_pdfPath);
            }
            else
            {
                // Check if the pdf is there, If Yes Delete It. Because we will download the fresh one just in a moment
                if (File.Exists(_pdfFilePath))
                {
                    File.Delete(_pdfFilePath);
                }
            }

            // This will be executed when the pdf download is completed
            _webClient.DownloadDataCompleted += OnPDFDownloadCompleted;
            // Lets downlaod the PDF Document
            var url = new Uri(_pdfURL);
            _webClient.DownloadDataAsync(url);
        }

        private void OnPDFDownloadCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            // Okay the download's done, Lets now save the data and reload the webview.
            var pdfBytes = e.Result;
            File.WriteAllBytes(_pdfFilePath, pdfBytes);

            if (File.Exists(_pdfFilePath))
            {
                var bytes = File.ReadAllBytes(_pdfFilePath);
            }

            _webView.LoadUrl("file:///android_asset/pdfviewer/index.html?file=" + _pdfFilePath);

            //AndHUD.Shared.Dismiss();
        }*/
    }
}