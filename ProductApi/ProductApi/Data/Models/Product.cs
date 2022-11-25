using System.ComponentModel.DataAnnotations;

namespace ProductApi.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(25)]
        public string? ProductNumber { get; set; }
        public ProductSubcategory? ProductSubcategory { get; set; }
        
    }
}
