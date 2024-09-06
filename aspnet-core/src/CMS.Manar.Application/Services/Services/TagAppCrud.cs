
using Abp.Application.Services.Dto;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using CMS.Manar.Dtos.Services;
using CMS.Manar.Dtos.Tags;
using CMS.Manar.Entities.Tags;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Manar.Dtos.Helpers;
using Microsoft.EntityFrameworkCore;
using Abp.Linq.Extensions;
using Abp.Extensions;

namespace CMS.Manar.Services.Services
{
    public class TagAppCrud : AsyncCrudAppService<Tag, TagDto, int, PagedResultDto, CreateTagDto, TagDto>, ITagAppCrud
    {
        public TagAppCrud(IRepository<Tag> tagRepository)
            : base(tagRepository)
        { }

        public override async Task<TagDto> CreateAsync(CreateTagDto input)
        {
            var slugExist = await Repository
                    .FirstOrDefaultAsync(a => a.Slug == input.Slug);
            if (slugExist == null)
            {
                var obj = ObjectMapper.Map<Tag>(input);
                var objId = await Repository.InsertAndGetIdAsync(obj);
                return ObjectMapper.Map<TagDto>(obj);
            }
            return null;
        }

        public override async Task<TagDto> UpdateAsync(TagDto input)
        {
            var obj = await Repository.GetAllIncluding(a => a.Translations)
                .FirstOrDefaultAsync(a => a.Id == input.Id);
            var slugExist = await Repository
                            .FirstOrDefaultAsync(p => p.Slug == input.Slug && p.Id != input.Id);

            if (slugExist == null)
            {
                await Repository.UpdateAsync(ObjectMapper.Map(input, obj));
                return ObjectMapper.Map<TagDto>(obj);
            }
            else
            {
                return null;
            }
        }

        public override async Task<TagDto> GetAsync(EntityDto<int> input)
        {
            var obj = await Repository.GetAllIncluding(a => a.Translations)
                      .FirstOrDefaultAsync(a => a.Id == input.Id);
            var objDto = ObjectMapper.Map<TagDto>(obj);
            return objDto;
        }

        public async Task<List<TagDto>> GetListAsync()
        {
            var objs = await Repository.GetAllIncluding(a => a.Translations)
                      .ToListAsync();
            var objsDto = ObjectMapper.Map<List<TagDto>>(objs);
            return objsDto;
        }
        protected override IQueryable<Tag> CreateFilteredQuery(PagedResultDto input)
        {
            var list = Repository.GetAllIncluding(a => a.Translations)
                .WhereIf(!input.Slug.IsNullOrWhiteSpace(), x => x.Slug.Contains(input.Slug));

            if (input.language != null)
            {
                foreach (var item in list)
                {
                    item.Translations = item.Translations.Where(t => t.Language == input.language).ToList();
                }
            }
            return list;
        }
    }
}
