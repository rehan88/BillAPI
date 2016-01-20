using System.Net.Http.Headers;
using System.Web.Http;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

namespace Bill.API.Configs
{
    namespace Configs
    {
        public class StartupConfig
        {            
            public void Configure(IAppBuilder appBuilder, IKernel kernel)
            {
                var config = new HttpConfiguration();

                config.MapHttpAttributeRoutes();
                config.MapDefinedRoutes();
                config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

                appBuilder.UseNinjectMiddleware(() => kernel);
                appBuilder.UseNinjectWebApi(config);
            }
        }
    }
}