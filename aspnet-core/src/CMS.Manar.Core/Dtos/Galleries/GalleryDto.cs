

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CMS.Manar.Dtos.Services;
using CMS.Manar.Entities.Galleries;
using CMS.Manar.Entities.Services;
using System.Collections.Generic;

namespace CMS.Manar.Dtos.Galleries
{
    [AutoMap(typeof(Gallery))]
    public class GalleryDto : EntityDto
    {
        public ICollection<ImageDto> Images { get; set; }
        public int ServiceId { get; set; }
        public ServiceDto Service { get; set; }
        public GalleryDto(ICollection<ImageDto> images)
        {
            Images = images;
        }
    }
}
