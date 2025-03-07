using System.ComponentModel.DataAnnotations;

namespace EFCoreDay2.Models.Entity
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
