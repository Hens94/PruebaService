using Microsoft.AspNetCore.Mvc;
using PruebaService_App.Contracts;
using PruebaService_Common.Interfaces;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaService_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanet _planet;

        public PlanetController(IPlanet planet)
        {
            _planet = planet;
        }

        [HttpGet]
        public async Task<IResult> Get() =>
            await _planet.GetAll();
    }
}
