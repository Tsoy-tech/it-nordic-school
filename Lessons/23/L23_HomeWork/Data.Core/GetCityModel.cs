using Cities.Data.Core;
using System.ComponentModel.DataAnnotations;

namespace L23_HomeWork.Cities.Data.Core
{
    public class GetCityModel : CityModel
    {
        public int Id { get; set; }

        public GetCityModel(int id, string name, string desc = null, int numberOfPoi = 0)
        {
            Id = id;
            Name = name;
            Description = desc;
            NumberOfPoi = numberOfPoi;
        }
    }
}
