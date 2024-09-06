

using CMS.Manar.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CMS.Manar.Entities.Services;

namespace CMS.Manar.EntityFrameworkCore.Configurations
{
    public class ServiceCategoryConfigurations : IBaseEntityConfiguration, IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.ToTable("ServiceCategory");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

        }
    }
}

