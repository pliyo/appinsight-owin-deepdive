using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ReservationController : ApiController
    {
        [HttpGet]
        [Route("Create")]
        public IHttpActionResult Reserve()
        {
            return Ok();
        }
    }
}