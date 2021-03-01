using Cities.Model;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cities.Services
{
    public class JsonFileCityService
    {
        public JsonFileCityService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; set; }
        private string JsonFileName
        {
            get
            {
                return Path.Combine(WebHostEnvironment.ContentRootPath, "data", "cities.json");
            }
        }

        private IEnumerable<City> DeserializeCity()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<City[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public IEnumerable<City> GetCities()
        {
            return DeserializeCity();
        }
        public City GetCityByPlate(string plate)
        {
            return DeserializeCity().Where(q => q.Plate == plate).FirstOrDefault();
        }
        public City GetCityByName(string cityName)
        {
            return DeserializeCity().Where(q => q.Name == cityName).FirstOrDefault();
        }
    }
}
