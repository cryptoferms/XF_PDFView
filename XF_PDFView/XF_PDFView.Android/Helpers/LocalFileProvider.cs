using System.IO;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using XF_PDFView.Droid.Helpers;
using XF_PDFView.Helpers;
[assembly: Xamarin.Forms.Dependency(typeof(LocalFileProvider))]
namespace XF_PDFView.Droid.Helpers
{
    public class LocalFileProvider : ILocalFileProvider
    {

        private readonly string _rootDir = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "pdfjs");

        public async Task<string> SaveFileToDisk(Stream pdfStream, string fileName)
        {
            if (!Directory.Exists(_rootDir))
                Directory.CreateDirectory(_rootDir);

            var filePath = Path.Combine(_rootDir, fileName);

            using (var memoryStream = new MemoryStream())
            {
                await pdfStream.CopyToAsync(memoryStream);
                File.WriteAllBytes(filePath, memoryStream.ToArray());
            }

            return filePath;
        }
    }
}