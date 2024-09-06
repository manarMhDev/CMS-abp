

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CMS.Manar.Authorization.Users;
using CMS.Manar.Entities.Services;
using System.Collections.Generic;
using System;
using CMS.Manar.Dtos.Galleries;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Manar.Dtos.Services
{
    [AutoMap(typeof(Service))]
    public class ServiceDto : EntityDto
    {
        public string Slug { get; set; }
        public string Image { get; set; }
        public string Thumbnail { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreationTime { get; set; }
        public virtual User Creator { get; set; }
        public virtual ServiceCategoryDto Category { get; set; }
        public virtual GalleryDto Gallery { get; set; }
        public ICollection<ServiceTagDto> ServiceTags { get; set; }
        public ICollection<ServiceTranslationDto> Translations { get; set; }
    }
    [AutoMap(typeof(ServiceTranslation))]
    public class ServiceTranslationDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaExcerpt { get; set; }
        public string MetaDescription { get; set; }
        public string Duration { get; set; }
        public string Language { get; set; }
    }
}
