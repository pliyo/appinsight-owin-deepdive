using Microsoft.Owin;
using Owin;
using System.Web.Http;
using ApplicationInsights.OwinExtensions;
using AppInsightOwinDeepDive.App_Start;
using AppInsightOwinDeepDive.Jobs;

[assembly: OwinStartup("StartUp", typeof(StartUp))]

namespace AppInsightOwinDeepDive.App_Start
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