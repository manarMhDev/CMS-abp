

using Abp.Application.Services.Dto;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using CMS.Manar.Dtos.Services;
using CMS.Manar.Entities.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Manar.Dtos.Helpers;
using Microsoft.EntityFrameworkCore;
using Abp.Extensions;

namespace CMS.Manar.Services.Services
{
    public class ServiceCategoryAppCrud : AsyncCrudAppService<ServiceCategory, ServiceCategoryDto, int, PagedResultDto, CreateServiceCategoryDto, ServiceCategoryDto>, IServiceCategoryAppCrud
    {
        public ServiceCategoryAppCrud(IRepository<ServiceCategory> ServiceCategoryRepository)
            : base(ServiceCategoryRepository)
        { }

        public override async Task<ServiceCategoryDto> CreateAsync(CreateServiceCategoryDto input)
        {
            var slugExist = await Repository
                    .FirstOrDefaultAsync(a => a.Slug == input.Slug);
            if (slugExist == null)
            {
                var obj = ObjectMapper.Map<ServiceCategory>(input);
                var objId = await Repository.InsertAndGetIdAsync(obj);
                return ObjectMapper.Map<ServiceCategoryDto>(obj);
            }
            return null;
        }

        public override async Task<ServiceCategoryDto> UpdateAsync(ServiceCategoryDto input)
        {
            var obj = await Repository.GetAllIncluding(a => a.Translations)
                .FirstOrDefaultAsync(a => a.Id == input.Id);
            var slugExist = await Repository
                            .FirstOrDefaultAsync(p => p.Slug == input.Slug && p.Id != input.Id);

            if (slugExist == null)
            {
                await Repository.UpdateAsync(ObjectMapper.Map(input, obj));
                return ObjectMapper.Map<ServiceCategoryDto>(obj);
            }
            else
            {
                return null;
            }
        }

        public override async Task<ServiceCategoryDto> GetAsync(EntityDto<int> input)
        {
            var obj = await Repository.GetAllIncluding(a => a.Translations)
                      .FirstOrDefaultAsync(a => a.Id == input.Id);
            var objDto = ObjectMapper.Map<ServiceCategoryDto>(obj);
            return objDto;
        }

        public async Task<List<ServiceCategoryDto>> GetListAsync()
        {
            var objs = await Repository.GetAllIncluding(a => a.Translations)
                      .ToListAsync();
            var objsDto = ObjectMapper.Map<List<ServiceCategoryDto>>(objs);
            return objsDto;
        }

        protected override IQueryable<ServiceCategory> CreateFilteredQuery(PagedResultDto input)
        {
            var list = Repository.GetAllIncluding(a => a.Translations)
                .WhereIf(!input.Slug.IsNullOrWhiteSpace(), x => x.Slug.Contains(input.Slug));

            return list;
        }
    }
}
