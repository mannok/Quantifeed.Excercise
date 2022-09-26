using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Quantifeed.Excercise.EntityFrameworkCore;
using Quantifeed.Excercise.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Quantifeed.Excercise.Web.Tests
{
    [DependsOn(
        typeof(ExcerciseWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ExcerciseWebTestModule : AbpModule
    {
        public ExcerciseWebTestModule(ExcerciseEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ExcerciseWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ExcerciseWebMvcModule).Assembly);
        }
    }
}