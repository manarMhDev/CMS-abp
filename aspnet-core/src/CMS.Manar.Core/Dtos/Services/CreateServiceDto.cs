

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CMS.Manar.Dtos.Galleries;
using CMS.Manar.Dtos.Tags;
using CMS.Manar.Entities.Services;
using System.Collections.Generic;

namespace CMS.Manar.Dtos.Services
{
    [AutoMap(typeof(Service))]
    public class CreateServiceDto : EntityDto
    {
        public string Slug { get; set; }
        public string Image { get; set; }
        public string Thumbnail { get; set; }
        public int CategoryId { get; set; }
        public ICollection<ServiceTranslationDto> Translations { get; set; }
        public ICollection<TagDto> Tags { get; set; }
        public GalleryDto Gallery { get; set; }
        public CreateServiceDto()
        {

        }
        public CreateServiceDto(string slug, string image, string thumbnail,
            int categoryId,
            GalleryDto gallery,
            ICollection<ServiceTranslationDto> translations,
            ICollection<TagDto> tags = null)
        {
            Slug = slug;
            Image = image;
            Thumbnail = thumbnail;
            CategoryId = categoryId;
            Gallery = gallery;
            Translations = translations;
            Tags = tags;
        }
    }
}
