using System.Web.Http;

namespace AppInsightOwinDeepDive.Controllers
{
    public class HomeController : ApiController
    {
        [Route("home")]
        [HttpGet]
        public string Index()
        {
            var something = "something";
            return something;
        }
    }
}