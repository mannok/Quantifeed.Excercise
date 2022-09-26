using Abp.MultiTenancy;
using Quantifeed.Excercise.Authorization.Users;

namespace Quantifeed.Excercise.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
