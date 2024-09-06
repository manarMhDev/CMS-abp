using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CMS.Manar.Services.MediaManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Manar.Services.MediaManagement
{
    public interface IMediaManagementAppService : IApplicationService
    {
        public Task<PagedResultDto<FileResponseModel>> GetMediaListAsync(PagedFilesResultRequestDto input);
        public Task<string> UploadFile(UploadFileModel model);
        public Task<List<string>> GetDirectories(string path);
        public Task<bool> AddFolder(string folderName, string folderPath = null);
        public Task<bool> DeleteFile(string filePath);
        public Task<bool> DeleteFolder(string folderPath);
    }
}
