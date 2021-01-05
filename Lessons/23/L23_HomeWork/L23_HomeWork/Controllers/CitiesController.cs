using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using L23_HomeWork.Cities.Data.Core;
using L23_HomeWork.Cities.Data.InMemory;

namespace L23_HomeWork.Controllers
{
    [Route(template: "/api/cities/")]
    public class CitiesController : Controller
    {
        private ILogger<CitiesController> _logger;
        private static ICitiesDataStore _dataStore = new CitiesDataStore();

        public CitiesController(ILogger<CitiesController> logger, ICitiesDataStore dataStore) 
        {
            _logger = logger;
            _dataStore = dataStore;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            _logger.LogInformation($"{nameof(GetCities)} called");

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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (addCityModel == null)
                return BadRequest();

            if (_dataStore.Cities.FirstOrDefault(c => c.Name == addCityModel.Name) != null)
                return Conflict("The city with name specified already exists");

            int newId = _dataStore.GetNewId();
            var city = new City(newId, addCityModel.Name, addCityModel.Description, addCityModel.NumberOfPoi);

            _dataStore.Cities.Add(city);

            var getCityModel = new GetCityModel(newId, addCityModel.Name, addCityModel.Description, addCityModel.NumberOfPoi);

            return CreatedAtAction("GetCity", new { id = newId }, getCityModel);
        } 

        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, [FromBody] UpdateCityModel updateCityModel)
        {            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (updateCityModel == null)
                return BadRequest();

            var city = _dataStore.Cities.Where(c => c.Id == id).FirstOrDefault();

            if (city == null)
                return NotFound();

            city.Name = updateCityModel.Name;
            city.Description = updateCityModel.Description;
            city.NumberOfPoi = updateCityModel.NumberOfPoi;

            _dataStore.Cities.Remove(city);
            _dataStore.Cities.Add(city);

            return Ok(city);
        } 

        [HttpPatch("{id}")]
        public IActionResult PatchCity(int id, [FromBody] UpdateCityModel model)
        {            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           
            if (model == null)
                return BadRequest();

            City city = _dataStore.Cities.Where(c => c.Id == id).FirstOrDefault();

            if (city == null)
                return NotFound();

            var updateCityModel = new UpdateCityModel(city.Name, city.Description, city.NumberOfPoi);

            JsonPatchDocument<UpdateCityModel> patchCityDoc = new JsonPatchDocument<UpdateCityModel>();
            
            if(model.ReplaceName == true)
                patchCityDoc.Replace(x => x.Name, model.Name);

            if (model.ReplaceDescription == true)
                patchCityDoc.Replace(x => x.Description, model.Description);

            if (model.ReplaceNumberOfPoi == true)
                patchCityDoc.Replace(x => x.NumberOfPoi, model.NumberOfPoi);

            patchCityDoc.ApplyTo(updateCityModel);

            if (city.Name != updateCityModel.Name)
                city.Name = updateCityModel.Name;

            if (city.Description != updateCityModel.Description)
                city.Description = updateCityModel.Description;

            if (city.NumberOfPoi != updateCityModel.NumberOfPoi)
                city.NumberOfPoi = updateCityModel.NumberOfPoi;

            _dataStore.Cities.Remove(city);
            _dataStore.Cities.Add(city);

            return Ok(city);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            City city = _dataStore.Cities.Where(c => c.Id == id).FirstOrDefault();

            if (city == null)
                return NotFound();

            _dataStore.Cities.Remove(city);

            return NoContent();
        }
        //Newton required!
        /*public IActionResult PatchCity2(int id, [FromBody] JsonPatchDocument<UpdateCityModel> patchCityDoc)
        {
            if (patchCityDoc == null)
                return BadRequest();

            City city = _dataStore.Cities.Where(c => c.Id == id).FirstOrDefault();

            if (city == null)
                return NotFound();

            var updateCityModel = new UpdateCityModel(city.Name, city.Description, city.NumberOfPoi);

            patchCityDoc.ApplyTo(updateCityModel);

            if (patchCityDoc == null)
                return BadRequest();

            if(city.Name != updateCityModel.Name)
                city.Name = updateCityModel.Name;

            if (city.Description != updateCityModel.Description)
                city.Description = updateCityModel.Description;

            if(city.NumberOfPoi != updateCityModel.NumberOfPoi)
                city.NumberOfPoi = updateCityModel.NumberOfPoi;

            _dataStore.Cities.Remove(city);
            _dataStore.Cities.Add(city);

            return Ok(city);
        }*/
    }
}
