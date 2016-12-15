using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Acme.PhoneBook.Configuration;

namespace Acme.PhoneBook.Web.Configuration
{
    public static class HostingEnvironmentExtensions
    {
        public static IConfigurationRoot GetAppConfiguration(this IHostingEnvironment env)
        {
            return AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName, env.IsDevelopment());
        }
    }
}