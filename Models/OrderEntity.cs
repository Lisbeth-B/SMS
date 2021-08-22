using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SalesManagementSystem.Models
{
    public class OrderEntity
    {
        [Key]
        [Required]
        [Remote("IsOrderIdAvialable", "Validation", HttpMethod = "POST", ErrorMessage = "Order with specified id already exists")]
        public int Id { get => id; set => id = value; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTimeOffset Date { get => date; set => date = value; }

        [Required]
        [Remote("IsConsultantIdValid", "Validation", HttpMethod = "POST", ErrorMessage = "Customer with specified id does not exist")]
        public int ConsultantId { get => consultantId; set => consultantId = value; }

        [Remote("IsOrderLineItemsValid", "Validation", HttpMethod = "POST", ErrorMessage = "Bla")]
        public List<OrderLineItemEntity> OrderLineItems { get => orderLineItems; set => orderLineItems = value; }

        private int id;
        private DateTimeOffset date;
        private int consultantId;
        private List<OrderLineItemEntity> orderLineItems;

        public OrderEntity()
        {
            orderLineItems = new List<OrderLineItemEntity>();
        }

        public OrderEntity(int id, DateTimeOffset date, int consultantId, List<OrderLineItemEntity> orderLineItems) : base()
        {
            this.id = id;
            this.date = date;
            this.consultantId = consultantId;
            this.OrderLineItems = orderLineItems;
        }
    }
}