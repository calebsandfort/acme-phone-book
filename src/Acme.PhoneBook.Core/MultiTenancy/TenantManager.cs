using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Acme.PhoneBook.Editions;
using Acme.PhoneBook.Users;

namespace Acme.PhoneBook.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore
            ) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore
            )
        {
        }
    }
}