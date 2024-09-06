
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System.Collections.Generic;

namespace CMS.Manar.Entities.Services
{
    public class ServiceCategory : CreationAuditedEntity, IMultiLingualEntity<CategoryTranslation>
    {
        public string Slug { get; set; }
        public ICollection<CategoryTranslation> Translations { get; set; }
        public ICollection<Service> Services { get; set; }
        public ServiceCategory()
        {

        }
    }
    public class CategoryTranslation : Entity, IEntityTranslation<ServiceCategory>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ServiceCategory Core { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }
    }
}
