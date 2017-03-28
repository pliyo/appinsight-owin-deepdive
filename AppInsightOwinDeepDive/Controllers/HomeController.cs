using System.Web.Http;

namespace AppInsightOwinDeepDive.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            var something = "something";
            return something;
        }
    }
}