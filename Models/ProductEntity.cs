using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SalesManagementSystem.Models
{
    public class ProductEntity
    {
        [Key]
        [Required]
        [Display(Name = "Code")]
        [Remote("IsProductCodeAvialable", "Validation", HttpMethod = "POST", ErrorMessage = "Product with specified id already exists")]
        public int Code { get => code; set => code = value; }

        [Required]
        [StringLength(50)]
        public string Name { get => name; set => name = value; }

        [Required]
        [RegularExpression(@"^(?!0\d|$)\d*(\.\d{1,4})?$", ErrorMessage = "Price can't have more than 4 decimal places")]
        public decimal Price { get => price; set => price = value; }

        private int code;
        private string name;
        private decimal price;

        public ProductEntity()
        {
        }

        public ProductEntity(int code, string name, decimal price)
        {
            this.code = code;
            this.name = name;
            this.price = price;
        }
    }
}