using SalesManagementSystem.Domain;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SalesManagementSystem.Models
{
    public class OrderLineItemEntity
    {
        [Key]
        [Required]
        //[Remote("IsProductCodeValid", "Validation", ErrorMessage = "Product with specified code does not exist")]
        [ProductCode(ErrorMessage = "Product with specified code does not exist")]
        public int ProductCode { get => productCode; set => productCode = value; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than 0")]
        public int Quantity { get => quantity; set => quantity = value; }

        private int productCode;
        private int quantity; 

        public OrderLineItemEntity()
        {
        }

        public OrderLineItemEntity(int code, int quantity)
        {
            this.productCode = code;
            this.quantity = quantity;
        }
    }
}