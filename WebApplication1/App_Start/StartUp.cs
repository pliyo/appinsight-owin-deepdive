using ApplicationInsights.OwinExtensions;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using WebApplication1.App_Start;
using WebApplication1.Jobs;

[assembly: OwinStartup(typeof(StartUp))]

namespace WebApplication1.App_Start
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);
            JobScheduler.Start();

            app.UseApplicationInsights();
            app.UseWebApi(config);
        }
    }
}