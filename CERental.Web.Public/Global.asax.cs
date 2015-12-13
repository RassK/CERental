using Castle.Windsor;
using Castle.Windsor.Installer;
using CERental.Core;
using CERental.Web.Public.Windsor;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CERental.Web.Public
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
           var _container = new WindsorContainer()
                .Install(FromAssembly.This());

            IoC.Setup(x => _container.Resolve(x));
            IoC.SetContainer(_container);

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_container));

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorCompositionRoot(_container));

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}