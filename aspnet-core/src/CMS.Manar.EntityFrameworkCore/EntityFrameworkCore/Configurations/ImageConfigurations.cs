

using CMS.Manar.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CMS.Manar.Entities.Galleries;

namespace CMS.Manar.EntityFrameworkCore.Configurations
{
    public class ImageConfigurations : IBaseEntityConfiguration, IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

        }
    }
}