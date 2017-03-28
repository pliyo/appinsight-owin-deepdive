using System.Web.Http;
using WebApplication1.Reservation;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class ReservationController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Reserve([FromBody]ReservationRequest reservation)
        {
            ReservationService.Create(reservation); 
            return Ok();
        }
    }
}