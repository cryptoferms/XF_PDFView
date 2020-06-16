using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using XF_PDFView.Controls;

namespace XF_PDFView.iOS.Renderers
{
    public class PdfWebViewRenderer : ViewRenderer<PdfWebView,UIWebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<PdfWebView> e)
        {
            base.OnElementChanged(e);
            if (Control==null)
            {
                SetNativeControl(new UIWebView());
            }
            if (e.OldElement !=null)
            {
                //Limpar
            }
            if (e.NewElement != null)
            {
                var customWebView = Element as PdfWebView;
                string fileName = customWebView.Uri;

                if (!string.IsNullOrEmpty(fileName))
                {
                    Control.LoadRequest(new NSUrlRequest(new NSUrl(fileName, false)));
                    Control.ScalesPageToFit = true;
                }
            }
        }
    }
}