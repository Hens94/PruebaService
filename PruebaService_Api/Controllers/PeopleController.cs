using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaService_App.Contracts;
using PruebaService_Common.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaService_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeople _people;

        public PeopleController(IPeople people)
        {
            _people = people;
        }

        [HttpGet]
        public async Task<IResult> Get() =>
            await _people.GetAll();

    }
}
