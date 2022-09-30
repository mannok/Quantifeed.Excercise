using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Quantifeed.Excercise.Configuration;
using Quantifeed.Excercise.Web.Host.DI.Interceptors;

namespace Quantifeed.Excercise.Web.Host.Startup
{
    [DependsOn(
       typeof(ExcerciseWebCoreModule))]
    public class ExcerciseWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ExcerciseWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            LogInterceptorRegistrar.Initialize(IocManager.IocContainer.Kernel);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ExcerciseWebHostModule).GetAssembly());
        }
    }
}
