
namespace ASPNET_databases.Data.Entities
{
    public class Tank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Mileage { get; set; }
        public string? Description { get; set; }
        public bool InStock { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }

        public int ClassId { get; set; }
        public Class? Class { get; set; }
    }
}
