using System.Reflection;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Acme.PhoneBook.Configuration;
using Acme.PhoneBook.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Zero.Configuration;

namespace Acme.PhoneBook.Web.Startup
{
    [DependsOn(
        typeof(PhoneBookApplicationModule), 
        typeof(PhoneBookEntityFrameworkModule), 
        typeof(AbpAspNetCoreModule))]
    public class PhoneBookWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public PhoneBookWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(PhoneBookConsts.ConnectionStringName);

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Navigation.Providers.Add<PhoneBookNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(PhoneBookApplicationModule).Assembly
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}