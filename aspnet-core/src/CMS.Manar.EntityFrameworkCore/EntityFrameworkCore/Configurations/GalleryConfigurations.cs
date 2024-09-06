

using CMS.Manar.Entities.Galleries;
using CMS.Manar.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CMS.Manar.EntityFrameworkCore.Configurations
{
    public class GalleryConfigurations : IBaseEntityConfiguration, IEntityTypeConfiguration<Gallery>
    {
        public void Configure(EntityTypeBuilder<Gallery> builder)
        {
            builder.ToTable("Gallery");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder
           .HasMany(g => g.Images)
           .WithOne(s => s.Gallery)
           .HasForeignKey(f => f.GalleryId);


        }
    }
}