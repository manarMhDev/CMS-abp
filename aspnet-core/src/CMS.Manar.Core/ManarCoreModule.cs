using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using AutoMapper;
using CMS.Manar.Authorization.Roles;
using CMS.Manar.Authorization.Users;
using CMS.Manar.Configuration;
using CMS.Manar.Dtos.Services;
using CMS.Manar.Dtos.Tags;
using CMS.Manar.Entities.Services;
using CMS.Manar.Entities.Tags;
using CMS.Manar.Localization;
using CMS.Manar.MultiTenancy;
using CMS.Manar.Timing;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CMS.Manar
{
    [DependsOn(typeof(AbpZeroCoreModule), typeof(AbpAutoMapperModule))]
    public class ManarCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            ManarLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = ManarConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();

            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = ManarConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = ManarConsts.DefaultPassPhrase;
            /* Modified Start */
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                CustomDtoMapper.CreateMappings(configuration, new MultiLingualMapContext(
                    IocManager.Resolve<ISettingManager>()
                ));
            });
            // Configuration.Features.Providers.Add<AppFeatureProvider>();
            /* Modified End */
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ManarCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
        internal static class CustomDtoMapper
        {
            public static void CreateMappings(IMapperConfigurationExpression configuration, MultiLingualMapContext context)
            {
                configuration.CreateMultiLingualMap<Tag, TagTranslation, TagDto>(context);
                configuration.CreateMultiLingualMap<ServiceCategory, CategoryTranslation, ServiceCategoryDto>(context);
                configuration.CreateMultiLingualMap<Service, ServiceTranslation, ServiceDto>(context);
            }
        }
    }
}
