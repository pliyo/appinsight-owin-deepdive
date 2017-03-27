using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("Home")]
        public string Index()
        {
            var something = "something";
            return something;
        }
    }
}