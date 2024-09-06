using Abp.Application.Services;
using CMS.Manar.MultiTenancy.Dto;

namespace CMS.Manar.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

