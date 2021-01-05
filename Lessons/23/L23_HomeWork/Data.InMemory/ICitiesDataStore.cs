using System.Collections.Generic;

namespace L23_HomeWork.Cities.Data.InMemory
{
    public interface ICitiesDataStore
    {
        List<City> Cities { get; }
        int GetNewId();
    }
}
