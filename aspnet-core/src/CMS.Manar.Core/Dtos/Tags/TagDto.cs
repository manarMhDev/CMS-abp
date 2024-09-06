

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CMS.Manar.Entities.Tags;
using System.Collections.Generic;

namespace CMS.Manar.Dtos.Tags
{

    [AutoMap(typeof(Tag))]
    public class TagDto : EntityDto
    {
        public string Slug { get; set; }
        public ICollection<TagTranslationDto> Translations { get; set; }
        public TagDto()
        {

        }
        public TagDto(string Slug, ICollection<TagTranslationDto> Translations)
        {
            this.Slug = Slug;
            this.Translations = Translations;
        }
    }
    [AutoMap(typeof(TagTranslation))]
    public class TagTranslationDto
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public TagTranslationDto()
        {

        }
        public TagTranslationDto(string Name, string Language)
        {
            this.Name = Name;
            this.Language = Language;
        }
    }
}
