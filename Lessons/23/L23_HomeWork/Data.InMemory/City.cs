﻿namespace L23_HomeWork.Cities.Data.InMemory
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPoi { get; set; }

        public City(int id, string name, string desc = null, int numberOfPoi = 0)
        {
            Id = id;
            Name = name;
            Description = desc;
            NumberOfPoi = numberOfPoi;
        }
    }
}
