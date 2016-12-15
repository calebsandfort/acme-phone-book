using Abp.Authorization;
using Acme.PhoneBook.Authorization.Roles;
using Acme.PhoneBook.MultiTenancy;
using Acme.PhoneBook.Users;

namespace Acme.PhoneBook.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
