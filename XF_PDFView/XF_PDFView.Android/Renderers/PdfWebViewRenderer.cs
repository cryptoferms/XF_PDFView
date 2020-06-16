using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XF_PDFView.Controls;
using XF_PDFView.Droid.Renderers;

[assembly: ExportRenderer(typeof(PdfWebView),typeof(PdfWebViewRenderer))]
namespace XF_PDFView.Droid.Renderers
{
    public class PdfWebViewRenderer : WebViewRenderer
    {
        public PdfWebViewRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement !=null)
            {
                var customWebView = Element as PdfWebView;

                Control.Settings.AllowFileAccess = true;
                Control.Settings.AllowFileAccessFromFileURLs = true;
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                if (!string.IsNullOrEmpty(customWebView.Uri)) 
                {
                    Control.LoadUrl($"file:///android_asset/pdfjs/web/viewer.html?file={System.Net.WebUtility.UrlEncode(customWebView.Uri)}");
                }
            }
        }
    }
}