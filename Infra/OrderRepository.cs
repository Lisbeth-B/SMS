using SalesManagementSystem.db;
using SalesManagementSystem.Domain;
using SalesManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesManagementSystem.Infra
{
    public class OrderRepository : IRepository<OrderEntity>
    {
        private readonly SalesManagementSystemEntities db;

        public OrderRepository(SalesManagementSystemEntities dbContext)
        {
            db = dbContext;
        }

        public void Add(OrderEntity order)
        {
            Order orderModel = new Order
            {
                Id = order.Id,
                ConsultantId = order.ConsultantId,
                Date = order.Date
            };

            db.Orders.Add(orderModel);

            foreach (OrderLineItemEntity item in order.OrderLineItems)
            {
                OrderLineItem orderItemModel = new OrderLineItem
                {
                    OrderId = order.Id,
                    ProductCode = item.ProductCode,
                    Quantity = item.Quantity
                };
                db.OrderLineItems.Add(orderItemModel);
            }

            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            List<OrderLineItem> orderLineItems = db.OrderLineItems.Where(item => item.OrderId == id).ToList();

            foreach (OrderLineItem item in orderLineItems)
            {
                db.OrderLineItems.Remove(item);
            }

            db.Orders.Remove(order);
            db.SaveChanges();
        }

        public OrderEntity GetById(int id)
        {
            Order order = db.Orders.Find(id);

            if (order == null)
            {
                return null;
            }

            OrderEntity orderEntity = ModelToEntity(order);

            return orderEntity;
        }

        private OrderEntity ModelToEntity(Order order)
        {
            List<OrderLineItem> orderLineItems = db.OrderLineItems.Where(o => o.OrderId == order.Id).ToList();

            List<OrderLineItemEntity> orderLineItemEntities = orderLineItems.Select(orderLineItem => new OrderLineItemEntity(
                    code: orderLineItem.ProductCode,
                    quantity: orderLineItem.Quantity
                    )).ToList();

            OrderEntity orderEntity = new OrderEntity(id: order.Id,
                                                      date: order.Date,
                                                      consultantId: order.ConsultantId,
                                                      orderLineItems: orderLineItemEntities);
            return orderEntity;
        }

        public void Update(OrderEntity order)
        {
            Order orderModel = db.Orders.Find(order.Id);
            orderModel.ConsultantId = order.ConsultantId;
            orderModel.Date = order.Date;
            db.SaveChanges();
        }

        public IEnumerable<OrderEntity> List()
        {
            List<Order> orders = db.Orders.ToList();
            return orders.Select(o => ModelToEntity(o)).ToList();
        }
    }
}