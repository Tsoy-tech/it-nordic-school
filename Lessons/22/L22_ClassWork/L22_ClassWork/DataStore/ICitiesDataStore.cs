using L22_ClassWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L22_ClassWork.DataStore
{
    public interface ICitiesDataStore
    {
        List<City> Cities { get; }
        int GetNewId();

    }
}
