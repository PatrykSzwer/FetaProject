
using Android.App;
using Android.Webkit;
using AndroidHUD;
using Com.Joanzapata.Pdfview;
using FetaProject.Droid.Fragments.Base;
using System;
using System.IO;
using System.Net;

namespace FetaProject.Droid.Fragments
{
    public class AboutPageFragment : BaseSlidePageFragment
    {
        private string _documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string _pdfPath;
        private string _pdfFileName = "thePDFDocument.pdf";
        private string _pdfFilePath;
        private WebView _webView;
        private string _pdfURL = @"http://sal.aalto.fi/publications/pdf-files/eluu11_public.pdf";
        private WebClient _webClient = new WebClient();
        private Activity _context;

        private PDFView pdfView;

        public AboutPageFragment(Activity context) : base(Resource.Layout.fragment_screen_slide_page_about)
        {
            _context = context;
        }

        public override void ViewInitialization()
        {
            _webView = FragmentView.FindViewById<WebView>(Resource.Id.webViewForPdf);
            _webView.Settings.JavaScriptEnabled = true;
            _webView.Settings.AllowFileAccessFromFileURLs = true;
            _webView.Settings.AllowUniversalAccessFromFileURLs = true;
            _webView.Settings.BuiltInZoomControls = true;
            _webView.SetWebChromeClient(new WebChromeClient());

            var pdf = "http://www.adobe.com/devnet/acrobat/pdfs/pdf_open_parameters.pdf";
            _webView.LoadUrl("http://drive.google.com/viewerng/viewer?embedded=true&url=" + pdf);
            //pdfView = FragmentView.FindViewById<PDFView>(Resource.Id.pdfView);
            //pdfView.FromAsset("test.pdf").Load();
            //var settings = _webView.Settings;
            //settings.JavaScriptEnabled = true;
            //settings.AllowFileAccessFromFileURLs = true;
            //settings.AllowUniversalAccessFromFileURLs = true;
            //settings.BuiltInZoomControls = true;
            //_webView.SetWebChromeClient(new WebChromeClient());

            //DownloadPDFDocument();
            //OpenPdfDocument();

        }

        private void DownloadPDFDocument()
        {
            AndHUD.Shared.Show(_context, "Downloading PDF\nPlease Wait ..", -1, MaskType.Clear);

            _pdfPath = _documentsPath + "/drawable";
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

            _webView.LoadUrl("file:///android_asset/PDFViewer/index.html?file=" + _pdfFilePath);

            AndHUD.Shared.Dismiss();
        }
    }
}