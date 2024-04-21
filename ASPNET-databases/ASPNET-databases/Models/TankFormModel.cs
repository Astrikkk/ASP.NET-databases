using System.ComponentModel.DataAnnotations;

namespace ASPNET_databases.Models
{
    public class TankFormModel
    {
        public int Id { get; set; }
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        [StringLength(4000, MinimumLength = 10)]
        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        public int Mileage { get; set; }
        public bool InStock { get; set; }

        public decimal Quantity { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        [Range(1, int.MaxValue)]
        public int ClassId { get; set; }
    }
}
