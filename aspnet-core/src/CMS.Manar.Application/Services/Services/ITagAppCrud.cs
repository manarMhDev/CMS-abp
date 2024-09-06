

using Abp.Application.Services;
using CMS.Manar.Dtos.Helpers;
using CMS.Manar.Dtos.Services;
using CMS.Manar.Dtos.Tags;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Manar.Services.Services
{
    public interface ITagAppCrud : IAsyncCrudAppService<TagDto, int, PagedResultDto, CreateTagDto, TagDto>
    {
        public Task<List<TagDto>> GetListAsync();
    }
}
