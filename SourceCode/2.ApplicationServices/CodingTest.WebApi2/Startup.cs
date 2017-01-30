using CodingTest.WebApi2.DependencyResolution;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(CodingTest.WebApi2.Startup))]

namespace CodingTest.WebApi2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);

            var config = new HttpConfiguration();
            config.DependencyResolver = new StructureMapWebApiDependencyResolver(StructuremapMvc.StructureMapDependencyScope.Container);
            WebApiConfig.Register(config);

            app.UseWebApi(config);
         }
    }
}
