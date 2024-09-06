

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CMS.Manar.Entities.Galleries;

namespace CMS.Manar.Dtos.Galleries
{
    [AutoMap(typeof(Image))]
    public class ImageDto : EntityDto
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public ImageDto(string path, string name)
        {
            this.Path = path; ;
            Name = name;
        }
    }
}
