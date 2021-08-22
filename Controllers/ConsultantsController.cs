using SalesManagementSystem.db;
using SalesManagementSystem.Domain;
using SalesManagementSystem.Infra;
using SalesManagementSystem.Models;
using System.Net;
using System.Web.Mvc;

namespace SalesManagementSystem.Controllers
{
    public class ConsultantsController : Controller
    {
        private readonly IRepository<ConsultantEntity> consultantRepository = new ConsultantRepository(new SalesManagementSystemEntities());

        public ConsultantsController()
        {
        }

        public ActionResult Index()
        {
            return View(consultantRepository.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultantEntity consultantEntity = consultantRepository.GetById(id.Value);
            if (consultantEntity == null)
            {
                return HttpNotFound();
            }
            return View(consultantEntity);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,IdNumber,Sex,DateOfBirth,ReferrerId")] ConsultantEntity consultantEntity)
        {
            if (ModelState.IsValid)
            {
                consultantRepository.Add(consultantEntity);
                return RedirectToAction("Index");
            }

            return View(consultantEntity);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultantEntity consultantEntity = consultantRepository.GetById(id.Value);
            if (consultantEntity == null)
            {
                return HttpNotFound();
            }
            return View(consultantEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,IdNumber,Sex,DateOfBirth,ReferrerId")] ConsultantEntity consultantEntity)
        {
            if (ModelState.IsValid)
            {
                consultantRepository.Update(consultantEntity);
                return RedirectToAction("Index");
            }
            return View(consultantEntity);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultantEntity consultantEntity = consultantRepository.GetById(id.Value);
            if (consultantEntity == null)
            {
                return HttpNotFound();
            }
            return View(consultantEntity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            consultantRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
