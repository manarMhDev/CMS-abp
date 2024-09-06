

using Abp.Application.Services.Dto;

namespace CMS.Manar.Dtos.Helpers
{
    public class PagedResultDto : PagedResultRequestDto
    {
        public string Slug { get; set; }
        public string Keyword { get; set; }
        public string language { get; set; }
    }
}
