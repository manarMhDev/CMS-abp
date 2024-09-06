

using Abp.Domain.Entities;
using CMS.Manar.Entities.Tags;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Manar.Entities.Services
{
    public class ServiceTag : Entity
    {
        public int ServiceId { get; set; }
        public int TagId { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public virtual Service Service { get; set; }

        [ForeignKey(nameof(TagId))]
        public virtual Tag Tag { get; set; }
    }
}
