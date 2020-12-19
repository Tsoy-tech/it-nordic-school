using Microsoft.AspNetCore.Mvc;

namespace L22_ClassWork.Models
{
    public class AddCityModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPoi { get; set; }

        public AddCityModel( string name, string desc = null, int numberOfPoi = 0)
        {
            Name = name;
            Description = desc;
            NumberOfPoi = numberOfPoi;
        }
        public AddCityModel() { }
    }
}
