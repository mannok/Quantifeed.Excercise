using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Quantifeed.Excercise.Authorization.Roles;
using Quantifeed.Excercise.Authorization.Users;
using Quantifeed.Excercise.MultiTenancy;

namespace Quantifeed.Excercise.EntityFrameworkCore
{
    public class ExcerciseDbContext : AbpZeroDbContext<Tenant, Role, User, ExcerciseDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ExcerciseDbContext(DbContextOptions<ExcerciseDbContext> options)
            : base(options)
        {
        }
    }
}
