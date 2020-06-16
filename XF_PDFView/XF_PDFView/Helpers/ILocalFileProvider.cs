using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace XF_PDFView.Helpers
{
    public interface ILocalFileProvider
    {
        Task<string> SaveFileToDisk(Stream stream, string fileName);
    }
}
