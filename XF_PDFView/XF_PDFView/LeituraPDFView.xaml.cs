using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_PDFView.Helpers;

namespace XF_PDFView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeituraPDFView : ContentPage
    {
        public LeituraPDFView()
        {
            InitializeComponent();

            CarregarPdf();
        }
        private void CarregarPdf()
        {
            var dependency = DependencyService.Get<ILocalFileProvider>();

            if (dependency == null)
            {
                DisplayAlert("Erro ao carregar dependencia", "Dependencia não encontrada", "OK");
                return;
            }
            var localPath = string.Empty;
            string url = "http://desenv1.algorix.com//Generix/Cons2ViaFaturaCliente.aspx?CdRede=9024&CdCliente=2002329&NuSeqFatura=57&IdUsu=2&ie6=rel.pdf&Tp=email";

            var fileName = Guid.NewGuid().ToString();

            using (var httpClient = new HttpClient())
            {
               var pdfStream = Task.Run(() => httpClient.GetStreamAsync(url)).Result;
                localPath =
                    Task.Run(() => dependency.SaveFileToDisk(pdfStream, $"{fileName}.pdf")).Result;
            }
            if (string.IsNullOrWhiteSpace(localPath))
            {
                DisplayAlert("Erro ao baixar o PDF", "Não foi possível encontrar o arquivo", "OK");

                return;
            }
            PdfView.Uri = localPath;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}