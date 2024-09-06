using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CMS.Manar.EntityFrameworkCore;
using CMS.Manar.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace CMS.Manar.Web.Tests
{
    [DependsOn(
        typeof(ManarWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ManarWebTestModule : AbpModule
    {
        public ManarWebTestModule(ManarEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ManarWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ManarWebMvcModule).Assembly);
        }
    }
}