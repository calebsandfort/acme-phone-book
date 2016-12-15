using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Acme.PhoneBook.Authorization;
using Acme.PhoneBook.Users;
using Microsoft.AspNetCore.Mvc;

namespace Acme.PhoneBook.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : PhoneBookControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }
    }
}