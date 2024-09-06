

using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;

namespace CMS.Manar.Helper.FileManagement.Helper.FileManagement
{
    public class FileManagement : IFileManagement
    {
        private readonly IHostingEnvironment _environment;
        public FileManagement(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public string SaveFile(string fileStr, string fileName,string directoryName=null)
        {
            if (directoryName == null)
            {
                directoryName = "uploads";
            }
            var directoryPath = Path.Combine(_environment.WebRootPath, directoryName);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            var ext = fileName.Substring(fileName.IndexOf("."));
            var data = fileStr.Substring(fileStr.IndexOf(",") + 1);
            string name = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ext;
            var filePath = Path.Combine(_environment.WebRootPath, directoryName, name);

            byte[] fileBytes = Convert.FromBase64String(data);
            var pathToStore = directoryName+"/" + name;
            File.WriteAllBytes(filePath, fileBytes);

            return pathToStore;
        }
    }
}
