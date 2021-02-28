using Cities.Model;
using Cities.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        public CitiesController(JsonFileCityService cityService)
        {
            CityService = cityService;
        }
        public JsonFileCityService CityService { get; }

        [HttpGet]
        public IEnumerable<City> Get()
        {
            return CityService.GetCities();
        }
    }
}
