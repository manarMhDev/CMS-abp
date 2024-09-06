using Abp.Application.Services.Dto;

namespace CMS.Manar.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

