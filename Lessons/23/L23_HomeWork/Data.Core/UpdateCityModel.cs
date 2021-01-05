using Cities.Data.Core;
using System.ComponentModel.DataAnnotations;

namespace L23_HomeWork.Cities.Data.Core
{
    public class UpdateCityModel : CityModel
    {
        [Range(typeof(bool), "false", "true")]
        public bool ReplaceDescription { get; set; }
        
        [Range(typeof(bool), "false", "true")]
        public bool ReplaceName { get; set; }

        [Range(typeof(bool), "false", "true")]
        public bool ReplaceNumberOfPoi { get; set; }

        public UpdateCityModel( string name, string desc = null, int numberOfPoi = 0)
        {
            Name = name;
            Description = desc;
            NumberOfPoi = numberOfPoi;
        }
        public UpdateCityModel() { }
    }
}
