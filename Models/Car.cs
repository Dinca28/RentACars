﻿namespace RentACars.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public string ImageUrl { get; set; } = null!;
        public decimal PricePerDay { get; set; }
        public string Location { get; set; } = null!;
    }
}
