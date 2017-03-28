using System.Web.Http;

namespace WebApplication1.Controllers
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