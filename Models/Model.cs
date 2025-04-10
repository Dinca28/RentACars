namespace RentACars.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BrandId { get; set; } // Foreign Key
        public Brand Brand { get; set; } // Navigation Property

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
