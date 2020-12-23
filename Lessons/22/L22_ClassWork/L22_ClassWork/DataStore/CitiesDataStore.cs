using L22_ClassWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L22_ClassWork.DataStore
{
    public class CitiesDataStore : ICitiesDataStore
    {
        public List<City> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<City>
            {
                new City(1, "Moscow", "asd", 896),
                new City(2, "St. Petersburg", "asd", 546),
                new City(3, "Los Angeles", "asd", 500)
            };
        }
        public int GetNewId()
        {
            return Cities.Select(c => c.Id).Max() + 1;
        }
    }
}
