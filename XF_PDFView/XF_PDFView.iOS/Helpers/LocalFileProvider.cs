﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using XF_PDFView.Helpers;

namespace XF_PDFView.iOS.Helpers
{
    public class LocalFileProvider : ILocalFileProvider
    {
        private readonly string _rootDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "pdfjs");

        public async Task<string> SaveFileToDisk(Stream stream, string fileName)
        {
            if (!Directory.Exists(_rootDir))
                Directory.CreateDirectory(_rootDir);

            var filePath = Path.Combine(_rootDir, fileName);

            using(var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                File.WriteAllBytes(filePath, memoryStream.ToArray());
            }

            return filePath;
        }
    }
}