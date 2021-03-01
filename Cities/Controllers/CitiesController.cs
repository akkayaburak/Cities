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
    [Route("")]
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

        [Route("/plate/{plate}")]
        [HttpGet]
        public City GetCityByPlate(int plate)
        {
            string plt = Convert.ToString(plate);
            City city = CityService.GetCityByPlate(plt);
            return city ?? null;
        }
        [Route("/{city}")]
        [HttpGet]
        public City GetCityByName(string cityName)
        {
            City city = CityService.GetCityByName(cityName);
            return city ?? null;
        }

    }
}
