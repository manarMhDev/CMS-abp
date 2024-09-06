

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CMS.Manar.Entities.Services;
using System.Collections.Generic;

namespace CMS.Manar.Dtos.Services
{
    [AutoMap(typeof(ServiceCategory))]
    public class ServiceCategoryDto : EntityDto
    {
        public string Slug { get; set; }
        public ICollection<ServiceCategoryTranslationDto> Translations { get; set; }
    }
    [AutoMap(typeof(CategoryTranslation))]
    public class ServiceCategoryTranslationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }

    }
}
