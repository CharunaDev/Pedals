using Autofac;
using Autofac.Integration.Mvc;
using Pedals.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;

namespace Pedals
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            // Parse the Entity Framework connection string
            var entityConnectionString = ConfigurationManager.ConnectionStrings["PedalsEntities"].ConnectionString;
            var entityConnectionStringBuilder = new EntityConnectionStringBuilder(entityConnectionString);

            // Extract the ADO.NET connection string
            var adoNetConnectionString = entityConnectionStringBuilder.ProviderConnectionString;
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<AccountService>().As<IAccountService>().WithParameter("connectionString", adoNetConnectionString);
            builder.RegisterType<DashboardService>().As<IDashboardService>().WithParameter("connectionString", adoNetConnectionString);


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
