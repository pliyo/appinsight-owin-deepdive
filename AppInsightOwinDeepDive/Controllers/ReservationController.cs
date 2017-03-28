using System.Web.Http;
using AppInsightOwinDeepDive.Reservation;
using AppInsightOwinDeepDive.Services;

namespace AppInsightOwinDeepDive.Controllers
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