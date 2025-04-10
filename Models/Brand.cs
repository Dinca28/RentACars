namespace RentACars.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; } = new List<Car>();
        public ICollection<Model> Models { get; set; } = new List<Model>(); 
    }

}
