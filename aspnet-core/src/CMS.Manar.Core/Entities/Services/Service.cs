

using Abp.Domain.Entities;
using CMS.Manar.Authorization.Users;
using CMS.Manar.Entities.Galleries;
using CMS.Manar.Entities.SEOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Manar.Entities.Services
{
    public class Service : SEO, IMultiLingualEntity<ServiceTranslation>
    {

        public string Image { get; set; }
        public string Thumbnail { get; set; }

        [ForeignKey(nameof(CreatorUserId))]
        public virtual User Creator { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual ServiceCategory Category { get; set; }
        public virtual Gallery Gallery { get; set; }
        public ICollection<ServiceTag> ServiceTags { get; set; }
        public ICollection<ServiceTranslation> Translations { get; set; }
    }
    public class ServiceTranslation : SEOTranslation, IEntityTranslation<Service>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public Service Core { get; set; }
        public int CoreId { get; set; }
        public string Language { get; set; }
    }
}
