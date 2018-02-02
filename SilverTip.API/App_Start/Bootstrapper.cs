using Autofac;
using Autofac.Integration.WebApi;
using SilverTip.BusinessObjects;
using SilverTip.BusinessObjects.Repositories;
using SilverTip.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace SilverTip.API.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerLifetimeScope();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(SupplierRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            // Services
            builder.RegisterAssemblyTypes(typeof(SupplierService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerLifetimeScope();

            IContainer container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}