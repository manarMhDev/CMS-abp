

using Abp.Application.Services;
using CMS.Manar.Dtos.Helpers;
using CMS.Manar.Dtos.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Manar.Services.Services
{
    public interface IServiceCategoryAppCrud : IAsyncCrudAppService<ServiceCategoryDto, int, PagedResultDto, CreateServiceCategoryDto, ServiceCategoryDto>
    {
        public Task<List<ServiceCategoryDto>> GetListAsync();
    }
}

