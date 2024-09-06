

using Abp.AutoMapper;
using CMS.Manar.Dtos.Tags;
using CMS.Manar.Entities.Tags;
using System.Collections.Generic;

namespace CMS.Manar.Dtos.Services
{
    [AutoMap(typeof(Tag))]
    public class CreateTagDto
    {
        public string Slug { get; set; }
        public ICollection<TagTranslationDto> Translations { get; set; }
        public CreateTagDto()
        {

        }
        public CreateTagDto(string Slug, ICollection<TagTranslationDto> Translations)
        {
            this.Slug = Slug;
            this.Translations = Translations;
        }
    }
}
