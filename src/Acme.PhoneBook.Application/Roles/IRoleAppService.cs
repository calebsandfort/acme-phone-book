using System.Threading.Tasks;
using Abp.Application.Services;
using Acme.PhoneBook.Roles.Dto;

namespace Acme.PhoneBook.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
