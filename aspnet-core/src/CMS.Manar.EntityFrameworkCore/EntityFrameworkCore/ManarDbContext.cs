using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CMS.Manar.Authorization.Roles;
using CMS.Manar.Authorization.Users;
using CMS.Manar.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using CMS.Manar.EntityFrameworkCore.Repositories;
using CMS.Manar.Entities.Services;
using CMS.Manar.Entities.Galleries;
using CMS.Manar.Entities.Tags;

namespace CMS.Manar.EntityFrameworkCore
{
    public class ManarDbContext : AbpZeroDbContext<Tenant, Role, User, ManarDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }

        public ManarDbContext(DbContextOptions<ManarDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            RegisterConfigurations(modelBuilder);
        }
        protected virtual void RegisterConfigurations(ModelBuilder modelBuilder)
        {
            //Debugger.Launch();
            var ConfigurationAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                                                                    .Where(x =>
                                                                                x.ManifestModule != null &&
                                                                                x.ManifestModule.Name.StartsWith("CMS.", StringComparison.OrdinalIgnoreCase))
                                                                    .ToList();
            var ConfigurationTypes = PickConfigurationTypes(ConfigurationAssemblies);
            foreach (var type in ConfigurationTypes)
            {
                modelBuilder.ApplyConfiguration((dynamic)Activator.CreateInstance(type));
            }
        }
        private IEnumerable<Type> PickConfigurationTypes(IEnumerable<Assembly> assemblies)
        {
            return assemblies.SelectMany(x => x.GetTypes()).Where(x => x.IsClass && !x.IsAbstract && typeof(IBaseEntityConfiguration).IsAssignableFrom(x));
        }
    }
}
