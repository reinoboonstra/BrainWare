using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BrainShark.BrainWare.WebApp.Controllers.API;
using BrainShark.BrainWare.WebApp.Infrastructure.Database;
using BrainShark.BrainWare.WebApp.Infrastructure.Services;

namespace BrainShark.BrainWare.WebApp
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterApiControllers(typeof(OrderController).Assembly);

            builder.RegisterType<Database>()
                .AsSelf()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<OrderService>().As<IOrderService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
