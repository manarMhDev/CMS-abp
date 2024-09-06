

using CMS.Manar.Entities.Services;
using CMS.Manar.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CMS.Manar.Entities.Galleries;

namespace CMS.Manar.EntityFrameworkCore.Configurations
{
    public class ServiceConfigurations : IBaseEntityConfiguration, IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Service");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.HasOne(a => a.Category)
                   .WithMany(c => c.Services)
                   .HasForeignKey(a => a.CategoryId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Creator)
                   .WithMany()
                   .HasForeignKey(a => a.CreatorUserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Gallery)
                   .WithOne(c => c.Service)
                   .HasForeignKey<Gallery>(a => a.ServiceId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
