using System.Web.Http;

namespace AppInsightOwinDeepDive.Controllers
{
    public class HealthController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Ok();
        }
    }
}