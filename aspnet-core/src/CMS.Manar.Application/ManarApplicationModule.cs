using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CMS.Manar.Authorization;

namespace CMS.Manar
{
    [DependsOn(
        typeof(ManarCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ManarApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ManarAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ManarApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
