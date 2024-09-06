


using CMS.Manar.Entities.Tags;
using CMS.Manar.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Manar.EntityFrameworkCore.Configurations
{
    public class TagConfigurations : IBaseEntityConfiguration, IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

        }
    }
}
