using Abp.Application.Services.Dto;

namespace CMS.Manar.Services.MediaManagement.Dtos
{
    public class PagedFilesResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public string folderPath { get; set; }
    }
}
