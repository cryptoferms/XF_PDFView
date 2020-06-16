using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF_PDFView
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            navegador.Source = "http://desenv1.algorix.com//Generix/Cons2ViaFaturaCliente.aspx?CdRede=9024&CdCliente=2002329&NuSeqFatura=57&IdUsu=2&ie6=rel.pdf&Tp=email";
        }

        [Obsolete]
        private void navegador_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Url.Contains(".pdf"))
            {
                //retornando a URL
                var pdfUrl = new Uri(e.Url);
                //Abrindo a URL do PSD com o navegador para o download
                Device.OpenUri(pdfUrl);
                e.Cancel = true;
            }
        }
    }
}
