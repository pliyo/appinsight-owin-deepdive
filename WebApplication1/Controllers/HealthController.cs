using System.Web.Http;

namespace AppInsightOwinDeepDive.Controllers
{
    public class HealthController : ApiController
    {
        [Route("healthstatus")]
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Ok();
        }
    }
}