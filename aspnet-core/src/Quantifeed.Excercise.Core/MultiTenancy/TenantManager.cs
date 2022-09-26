using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Quantifeed.Excercise.Authorization.Users;
using Quantifeed.Excercise.Editions;

namespace Quantifeed.Excercise.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
