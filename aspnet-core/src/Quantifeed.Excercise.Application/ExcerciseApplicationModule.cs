using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Quantifeed.Excercise.Authorization;

namespace Quantifeed.Excercise
{
    [DependsOn(
        typeof(ExcerciseCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ExcerciseApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ExcerciseAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ExcerciseApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
