using Abp.Application.Services;
using Abp.Dependency;
using Castle.Core;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using Castle.MicroKernel;
using Castle.MicroKernel.Handlers;
using Castle.Windsor.Diagnostics.Helpers;
using log4net;
using log4net.Repository.Hierarchy;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Quantifeed.Excercise.Web.Host.DI.Interceptors
{
    public class ErrorLogInterceptor : IInterceptor
    {
        public ILogger Logger { get; set; }
        private ILogger ErrorLogger { get; }

        public ErrorLogInterceptor(Castle.Core.Logging.ILoggerFactory loggingFactory)
        {
            Logger = NullLogger.Instance;
            ErrorLogger = loggingFactory.Create("ErrorLogger");
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.ReturnType == typeof(Task) || (invocation.Method.ReturnType.IsGenericType && invocation.Method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>)))
            {
                invocation.Proceed();
                ((Task)invocation.ReturnValue).ContinueWith(task =>
                {
                    ErrorLogger.ErrorFormat(task.Exception.InnerException, task.Exception.InnerException.Message);
                }, TaskContinuationOptions.OnlyOnFaulted);
            }
            else
            {
                try { invocation.Proceed(); }
                catch (Exception ex)
                {
                    ErrorLogger.ErrorFormat(ex, ex.Message);

                    throw;
                }
            }
        }
    }

    public static class LogInterceptorRegistrar
    {
        public static void Initialize(IKernel kernel)
        {
            kernel.ComponentRegistered += (string key, IHandler handler) =>
            {
                if (
                    new string[] { Assembly.GetExecutingAssembly().FullName, handler.ComponentModel.Implementation.Assembly.FullName }.Select(x => x.Split(",").First().Split(".").First()).Distinct().Count() != 1 // apply only to same solution projects
                )
                    return;

                if (handler.ComponentModel.Implementation.IsPublic && !typeof(IInterceptor).IsAssignableFrom(handler.ComponentModel.Implementation))
                    handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(ErrorLogInterceptor)));
            };
        }
    }
}
