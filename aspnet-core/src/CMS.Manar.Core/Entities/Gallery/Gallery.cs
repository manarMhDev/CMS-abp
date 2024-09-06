
using Abp.Domain.Entities.Auditing;
using CMS.Manar.Entities.Services;
using System.Collections.Generic;

namespace CMS.Manar.Entities.Galleries
{
    public class Gallery : CreationAuditedEntity
    {
        public  ICollection<Image> Images { get; set; } = new List<Image>();
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
