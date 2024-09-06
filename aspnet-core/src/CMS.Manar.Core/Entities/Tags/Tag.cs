using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using CMS.Manar.Entities.Services;
using System;
using System.Collections.Generic;


namespace CMS.Manar.Entities.Tags
{
    public class Tag : CreationAuditedEntity, IMultiLingualEntity<TagTranslation>
    {
        public string Slug { get; set; }
        public ICollection<TagTranslation> Translations { get; set; }
        public ICollection<ServiceTag> ServiceTags { get; set; }
    }
    public class TagTranslation : Entity, IEntityTranslation<Tag>
    {
        public string Name { get; set; }

        public Tag Core { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }
    }
}
