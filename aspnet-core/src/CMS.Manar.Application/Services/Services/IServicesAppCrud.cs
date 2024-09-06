

using Abp.Application.Services;
using CMS.Manar.Dtos.Helpers;
using CMS.Manar.Dtos.Services;

namespace CMS.Manar.Services.Services
{
    public interface IServicesAppCrud : IAsyncCrudAppService<ServiceDto, int, PagedResultDto, CreateServiceDto, CreateServiceDto>
    {
    }
}
