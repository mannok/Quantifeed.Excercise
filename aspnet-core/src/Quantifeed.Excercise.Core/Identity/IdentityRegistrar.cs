using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Quantifeed.Excercise.Authorization;
using Quantifeed.Excercise.Authorization.Roles;
using Quantifeed.Excercise.Authorization.Users;
using Quantifeed.Excercise.Editions;
using Quantifeed.Excercise.MultiTenancy;

namespace Quantifeed.Excercise.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>()
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpLogInManager<LogInManager>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
