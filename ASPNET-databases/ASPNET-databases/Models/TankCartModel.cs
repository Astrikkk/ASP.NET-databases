namespace ASPNET_databases.Models
{
    public class TankCartModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public bool InStock { get; set; }
        public string ImageUrl { get; set; }
        public string ClassName { get; set; }
        public int Quantity { get; set; }
        public int CountToBuy { get; set; }
    }
}