using System.Web.Http;
using WebActivatorEx;
using AppInsightOwinDeepDive;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace AppInsightOwinDeepDive
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration 
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "WebApplication1");
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}