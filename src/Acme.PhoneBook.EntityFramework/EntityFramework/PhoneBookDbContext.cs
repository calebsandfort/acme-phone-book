using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Microsoft.Extensions.Configuration;
using Acme.PhoneBook.Authorization.Roles;
using Acme.PhoneBook.Configuration;
using Acme.PhoneBook.MultiTenancy;
using Acme.PhoneBook.Users;
using Acme.PhoneBook.Web;

namespace Acme.PhoneBook.EntityFramework
{
    [DbConfigurationType(typeof(PhoneBookDbConfiguration))]
    public class PhoneBookDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */

        /* Default constructor is needed for EF command line tool. */
        public PhoneBookDbContext()
            : base(GetConnectionString())
        {

        }

        private static string GetConnectionString()
        {
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder()
                );

            return configuration.GetConnectionString(
                PhoneBookConsts.ConnectionStringName
                );
        }

        /* This constructor is used by ABP to pass connection string.
         * Notice that, actually you will not directly create an instance of PhoneBookDbContext since ABP automatically handles it.
         */
        public PhoneBookDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection. */
        public PhoneBookDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }
    }

    public class PhoneBookDbConfiguration : DbConfiguration
    {
        public PhoneBookDbConfiguration()
        {
            SetProviderServices(
                "System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance
            );
        }
    }
}
