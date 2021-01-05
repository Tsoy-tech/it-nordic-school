using System.ComponentModel.DataAnnotations;

namespace Cities.Data.Core
{
	public abstract class CityModel
	{
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255, ErrorMessage = "Description should be not longer than 255 characters")]
        public string Description { get; set; }

        [Range(0, 100)]
        public int NumberOfPoi { get; set; }
    }
}
