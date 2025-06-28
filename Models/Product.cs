using System.ComponentModel.DataAnnotations;

namespace InventoryApp.Models
{
    public class Product
    {
        [Required]
        public string Name { get; set; }

        [Key]
        [Required]
        public string ProductID { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
        public int Quantity { get; set; }
    }
}