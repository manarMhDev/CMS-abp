

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace CMS.Manar.Entities.SEOs
{
    public abstract class SEO : CreationAuditedEntity, IMultiLingualEntity<SEOTranslation>
    {
        public string Slug { get; set; }
        public ICollection<SEOTranslation> Translations { get; set; }
    }
    public class SEOTranslation : Entity, IEntityTranslation<SEO>
    {
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaExcerpt { get; set; }
        public string MetaDescription { get; set; }
        public SEO Core { get; set; }
        public int CoreId { get; set; }
        public string Language { get; set; }

    }
}
