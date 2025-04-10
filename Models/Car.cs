namespace RentACars.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? BrandId { get; set; }
        public Brand Brand { get; set; }

        public int? ModelId { get; set; }
        public Model Model { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public decimal? PricePerDay { get; set; }

        public byte[]? Image { get; set; }
        public int Year { get; set; }
    }
}
