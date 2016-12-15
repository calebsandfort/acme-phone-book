using Abp.AspNetCore.Mvc.Authorization;
using Acme.PhoneBook.Authorization;
using Acme.PhoneBook.MultiTenancy;
using Microsoft.AspNetCore.Mvc;

namespace Acme.PhoneBook.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : PhoneBookControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}