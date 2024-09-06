

using Abp.AutoMapper;
using CMS.Manar.Dtos.Tags;
using CMS.Manar.Entities.Services;

namespace CMS.Manar.Dtos.Services
{
    [AutoMap(typeof(ServiceTag))]
    public class ServiceTagDto
    {
        public int ServiceId { get; set; }
        public int TagId { get; set; }
        public virtual TagDto Tag { get; set; }
        public ServiceTagDto()
        {

        }
        public ServiceTagDto(int ServiceId, int TagId)
        {
            this.ServiceId = ServiceId;
            this.TagId = TagId;
        }
    }
}
