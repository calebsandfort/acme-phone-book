using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;

namespace Acme.PhoneBook.EntityFramework
{
    [DependsOn(
        typeof(PhoneBookCoreModule), 
        typeof(AbpZeroEntityFrameworkModule))]
    public class PhoneBookEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PhoneBookDbContext>());
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}