using SalesManagementSystem.db;
using SalesManagementSystem.Domain;
using SalesManagementSystem.Infra;
using SalesManagementSystem.Models;
using System.Net;
using System.Web.Mvc;

namespace SalesManagementSystem.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IRepository<OrderEntity> orderRepository = new OrderRepository(new SalesManagementSystemEntities());

        public ActionResult Index()
        {
            return View(orderRepository.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderEntity order = orderRepository.GetById(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Date,ConsultantId,OrderLineItems")] OrderEntity order)
        {
            if (ModelState.IsValid)
            {
                if (order.OrderLineItems.Count == 0)
                {
                    ModelState.AddModelError("OrderLineItems", "Please enter at least one order line item.");
                    return View(order);
                }

                orderRepository.Add(order);
                return RedirectToAction("Index");
            }

            return View(order);
        }

        [HttpPost]
        public ActionResult AddOrderItem([Bind(Include = "OrderLineItems")] OrderEntity order)
        {
            order.OrderLineItems.Add(null);
            return PartialView("OrderLineItems", order);
        }

        [HttpPost]
        public ActionResult RemoveOrderItem([Bind(Include = "OrderLineItems")] OrderEntity order, int id)
        {
            OrderLineItemEntity orderLineItem = order.OrderLineItems.Find(o => o.ProductCode == id);
            order.OrderLineItems.Remove(orderLineItem);

            return PartialView("OrderLineItems", order);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderEntity order = orderRepository.GetById(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,ConsultantId,OrderLineItems")] OrderEntity order)
        {
            if (ModelState.IsValid)
            {
                orderRepository.Update(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderEntity order = orderRepository.GetById(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            orderRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
