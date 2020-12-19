namespace L22_ClassWork.Models
{
    public class GetCityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPoi { get; set; }

        public GetCityModel(int id, string name, string desc = null, int numberOfPoi = 0)
        {
            Id = id;
            Name = name;
            Description = desc;
            NumberOfPoi = numberOfPoi;
        }
    }
}
