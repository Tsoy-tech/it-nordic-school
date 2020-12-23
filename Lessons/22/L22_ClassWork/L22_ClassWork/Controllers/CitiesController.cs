using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using L22_ClassWork.DataStore;
using L22_ClassWork.Models;
using Microsoft.AspNetCore.Mvc;

namespace L22_ClassWork.Controllers
{
    public enum Attribute
	{
        Name,
        Description,
        NumberOfPoi
	}

    [Route(template: "/api/cities/")]
    public class CitiesController : Controller
    {
        private static CitiesDataStore _dataStore = new CitiesDataStore();

        [HttpGet]
        public IActionResult GetCities()
        {
            List<City> cities = _dataStore.Cities;

            if (cities == null)
                return NotFound();

            List<GetCityModel> models = cities.Select(c => new GetCityModel(c.Id, c.Name, c.Description, c.NumberOfPoi)).ToList();

            return Ok(models);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            City city = _dataStore.Cities.Where(c => c.Id == id).FirstOrDefault();

            if (city == null)
                return NotFound();

            var model = new GetCityModel(city.Id, city.Name, city.Description, city.NumberOfPoi);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult AddCity([FromBody] AddCityModel addCityModel)
        {
            if (addCityModel == null)
                return BadRequest();

            int newId = _dataStore.GetNewId();
            var city = new City(newId, addCityModel.Name, addCityModel.Description, addCityModel.NumberOfPoi);

            _dataStore.Cities.Add(city);

            var getCityModel = new GetCityModel(newId, addCityModel.Name, addCityModel.Description, addCityModel.NumberOfPoi);

            return CreatedAtAction("GetCity", new { id = newId }, getCityModel);
        }

        [HttpPost("{id}")]
        public IActionResult UpdateCity(int id, Attribute attribute, string updatedAttribute)
        {
            City city = _dataStore.Cities.Where(c => c.Id == id).FirstOrDefault();

            if (city == null)
                return NotFound();

            switch (attribute)
            {
                case Attribute.Name:
                    if (updatedAttribute != city.Name && updatedAttribute != null)
                        city.Name = updatedAttribute;
                    break;

                case Attribute.Description:
                    if (updatedAttribute != city.Description && updatedAttribute != null)
                        city.Name = updatedAttribute;
                    break;

                case Attribute.NumberOfPoi:
                    try
                    {
                        int parsedAttribute = int.Parse(updatedAttribute);

                        if (parsedAttribute != city.NumberOfPoi )
                            city.NumberOfPoi = parsedAttribute;
                        break;
                    }
                    catch
					{
                        return BadRequest("Can't parse to integer!");
					}
            }

            var model = new GetCityModel(city.Id, city.Name, city.Description, city.NumberOfPoi);

            return Ok();
        }
    }
}
