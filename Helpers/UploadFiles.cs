using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ejecuciones.Helpers
{
    public class UploadFiles
    {
        public async Task<string> UploadPDF(IWebHostEnvironment webHostEnvironment, string folderPath, IFormFile file)
        {
           

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, folderPath);
            string folder = Path.GetDirectoryName(serverFolder);
            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(serverFolder);
            }

                await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return @"\" + folderPath;
        }
    }
}
