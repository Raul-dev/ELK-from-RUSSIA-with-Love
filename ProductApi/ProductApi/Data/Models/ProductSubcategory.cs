using System.ComponentModel.DataAnnotations;

namespace ProductApi.Data.Models
{
    public class ProductSubcategory
    {
        [Key]
        public int ProductSubcategoryID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
