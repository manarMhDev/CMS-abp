

using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Manar.Entities.Galleries
{
    public class Image : CreationAuditedEntity
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public int? GalleryId { get; set; }
        [ForeignKey(nameof(GalleryId))]
        public virtual Gallery Gallery { get; set; }
    }
}
