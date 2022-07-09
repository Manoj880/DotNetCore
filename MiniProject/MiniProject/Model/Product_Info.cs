using System.ComponentModel.DataAnnotations;
namespace MiniProject.Model
{
    public class Product_Info
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public float Price { get; set; }
        public string Brand { get; set; }
        public string ManufactureDate { get; set; }
        public string ExpirationDate { get; set; }
    }
}
