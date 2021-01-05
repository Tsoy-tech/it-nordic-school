using Cities.Data.Core;
using System.ComponentModel.DataAnnotations;

namespace L23_HomeWork.Cities.Data.Core
{
    public class AddCityModel : CityModel
    {
        public AddCityModel( string name, string desc = null, int numberOfPoi = 0)
        {
            Name = name;
            Description = desc;
            NumberOfPoi = numberOfPoi;
        }
        public AddCityModel() { }
    }
}
