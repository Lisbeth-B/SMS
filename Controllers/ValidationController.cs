using SalesManagementSystem.db;
using SalesManagementSystem.Domain;
using SalesManagementSystem.Infra;
using SalesManagementSystem.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI;

namespace SalesManagementSystem.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : Controller
    {
        private readonly IRepository<OrderEntity> _orderContext;
        private readonly IRepository<ConsultantEntity> _customerContext;
        private readonly IRepository<ProductEntity> _productContext;

        public ValidationController() : this(new SalesManagementSystemEntities()) { }

        public ValidationController(SalesManagementSystemEntities repository)
        {
            _orderContext = new OrderRepository(repository);
            _customerContext = new ConsultantRepository(repository);
            _productContext = new ProductRepository(repository);
        }

        public JsonResult IsConsultantIdAvialable(int Id)
        {
            ConsultantEntity consultant = _customerContext.GetById(Id);

            if (consultant != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsReferrerIdValid(int Id, int? ReferrerId)
        {
            if (ReferrerId == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            ConsultantEntity referralConsultant = _customerContext.GetById(ReferrerId.Value);
            if (referralConsultant == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            if (ReferrerId == Id)
            {
                return Json("A closed circle is not addmissible", JsonRequestBehavior.AllowGet);
            }

            return IsReferrerIdValid(Id, referralConsultant.ReferrerId);
        }

        public JsonResult IsProductCodeAvialable(int Code)
        {
            ProductEntity product = _productContext.GetById(Code);

            if (product != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsConsultantIdValid(int ConsultantId)
        {
            ConsultantEntity costumer = _customerContext.GetById(ConsultantId);

            if (costumer == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsOrderIdAvialable(int Id)
        {
            OrderEntity order = _orderContext.GetById(Id);

            if (order != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsProductCodeValid(int ProductCode)
        {
            ProductEntity product = _productContext.GetById(ProductCode);

            if (product == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsOrderLineItemsValid(List<OrderLineItemEntity> OrderLineItems)
        {
            if (OrderLineItems.Count == 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}