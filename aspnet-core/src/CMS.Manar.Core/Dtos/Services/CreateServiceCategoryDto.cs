

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CMS.Manar.Entities.Services;
using System.Collections.Generic;

namespace CMS.Manar.Dtos.Services
{
    [AutoMap(typeof(ServiceCategory))]
    public class CreateServiceCategoryDto : EntityDto
    {
        public string Slug { get; set; }
        public ICollection<ServiceCategoryTranslationDto> Translations { get; set; }
    }
}
