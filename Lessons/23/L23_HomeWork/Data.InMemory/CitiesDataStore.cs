using System.Collections.Generic;
using System.Linq;

namespace L23_HomeWork.Cities.Data.InMemory
{
    public class CitiesDataStore : ICitiesDataStore
    {
        public List<City> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<City>
            {
                new City(1, "Moscow", "Capital of Russia", 80),
                new City(2, "St. Petersburg", "Cultural capital of Russia", 99),
                new City(3, "Los Angeles", "The most populous county in the United States", 99)
            };
        }
        public int GetNewId()
        {
            return Cities.Select(c => c.Id).Max() + 1;
        }
    }
}
