using System.ComponentModel.DataAnnotations;

namespace EFCoreDay2.Models.Entity
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive.")]
        public double Price { get; set; }
        
        public string? Description { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();    
    }
}
