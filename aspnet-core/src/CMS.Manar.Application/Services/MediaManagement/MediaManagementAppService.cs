using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;
using CMS.Manar.Helper.FileManagement;
using CMS.Manar.Services.MediaManagement.Dtos;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Manar.Services.MediaManagement
{
    public class MediaManagementAppService : ApplicationService,IMediaManagementAppService
    {
        private readonly IHostingEnvironment _environment;
        private readonly IFileManagement _fileManagement;
        public MediaManagementAppService(IHostingEnvironment environment, IFileManagement fileManagement)
        { 
            _environment = environment;
            _fileManagement = fileManagement;
        }

        public async Task<PagedResultDto<FileResponseModel>> GetMediaListAsync(PagedFilesResultRequestDto input)
        {
            var directoryPath = Path.Combine(_environment.ContentRootPath, "wwwroot/uploads/media");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (input.folderPath != null && Directory.Exists(input.folderPath))
                directoryPath = input.folderPath;


            string[] files = Directory.GetFiles(directoryPath, "*", SearchOption.TopDirectoryOnly);
            var filesModel = new List<FileResponseModel>();
            foreach (var item in files)
            {
                var file = new FileResponseModel
                {
                    Name = Path.GetFileNameWithoutExtension(item),
                    Folder = Path.GetFileName(Path.GetDirectoryName(item)),
                    Type = Path.GetExtension(item),
                    Path = item
                };
                file.Url = Path.GetFileName(item);
                string folderPath = Path.GetDirectoryName(item);
                string folderName = Path.GetFileName(folderPath);
                while (!folderName.Equals("uploads"))
                {
                    file.Url = folderName + "/" + file.Url;
                    folderPath = Path.GetDirectoryName(folderPath);
                    folderName = Path.GetFileName(folderPath);
                }
                file.Url = folderName + "/" + file.Url;
                filesModel.Add(file);
            }
            var pagedFiles = filesModel.AsQueryable().PageBy(input.SkipCount, input.MaxResultCount);
            //return filesModel;
            return new PagedResultDto<FileResponseModel>(
                filesModel.Count(),
                pagedFiles.ToList()
            );
        }

        public async Task<string> UploadFile(UploadFileModel model)
        {
            if (model.FolderPath == null || model.FolderPath=="")
            {
                model.FolderPath = "uploads/media";
            }
            return _fileManagement.SaveFile(model.File, model.FileName, model.FolderPath);
        }

        public async Task<List<string>> GetDirectories(string path=null)
        {
            var directoryPath = Path.Combine(_environment.ContentRootPath, "wwwroot/uploads/media");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (path != null && Directory.Exists(path))
                directoryPath = path;

            return Directory.GetDirectories(directoryPath).ToList();
        }

        public async Task<bool> AddFolder(string folderName, string folderPath = null)
        {
            var directoryPath = Path.Combine(_environment.ContentRootPath, "wwwroot/uploads/media");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (folderPath != null && Directory.Exists(folderPath))
                directoryPath = folderPath;

            var newFolder = directoryPath + "/" + folderName;
            if (!Directory.Exists(newFolder) && folderName!="media")
            {
                Directory.CreateDirectory(newFolder);
            }
            return true;
        }

        public async Task<bool> DeleteFile(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)//check file exsit or not  
            {
                file.Delete();
            }
            return true;
        }

        public async Task<bool> DeleteFolder(string folderPath)
        {
            DirectoryInfo folder = new DirectoryInfo(folderPath);
            if (folder.Exists)//check file exsit or not  
            {
                folder.Delete();
            }
            return true;
        }
    }
}
