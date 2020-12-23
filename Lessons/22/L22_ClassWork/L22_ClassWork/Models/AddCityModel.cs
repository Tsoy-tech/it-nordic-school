using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace L22_ClassWork.Models
{
    public class AddCityModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255, ErrorMessage = "Description should be not longer than 255 characters")]
        public string Description { get; set; }

        [Range(0, 100)]
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
