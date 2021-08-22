using SalesManagementSystem.db;
using SalesManagementSystem.Domain;
using SalesManagementSystem.Infra;
using System;
using System.Web.Mvc;

namespace SalesManagementSystem.Controllers
{
    public class AnalyticFormsController : Controller
    {
        private readonly IOrderService analyticFormService = new AnalyticFormService(new SalesManagementSystemEntities());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrdersByConsultant(DateTimeOffset? StartDate,
                                               DateTimeOffset? EndDate)
        {
            return View(analyticFormService.GetOrdersByConsultant(StartDate, EndDate));
        }

        public ActionResult OrdersByProductPrice(DateTimeOffset? StartDate,
                                                 DateTimeOffset? EndDate,
                                                 decimal? MinPrice,
                                                 decimal? MaxPrice)
        {
            return View(analyticFormService.GetOrdersByProductPrice(StartDate, EndDate, MinPrice, MaxPrice));
        }

        public ActionResult ConsultantsByFrequentlySoldProduct(
                                                 DateTimeOffset? StartDate,
                                                 DateTimeOffset? EndDate,
                                                 int? ProductCode,
                                                 int? MinAmount)
        {

            return View(analyticFormService.GetConsultantsByFrequentlySoldProduct(StartDate, EndDate, ProductCode, MinAmount));
        }

        public ActionResult ConsultantsSales(DateTimeOffset? StartDate,
                                                 DateTimeOffset? EndDate)
        {
            return View(analyticFormService.GetConsultantsSales(StartDate, EndDate));
        }

        public ActionResult ConsultantsByFrequentlyAndProfitableProducts(DateTimeOffset? StartDate,
                                                                             DateTimeOffset? EndDate)
        {
            return View(analyticFormService.GetConsultantsByFrequentlyAndProfitableProducts(StartDate, EndDate));
        }
    }
}
