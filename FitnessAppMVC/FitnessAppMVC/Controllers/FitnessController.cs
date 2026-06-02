using System.Web.Mvc;

namespace FitnessAppMVC.Controllers
{
    public class FitnessController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string address, string phone, int? id, bool hasPool)
        {
            string workingHours = Request.Form["workingHours"];
            string hasPoolForm = Request.Form["hasPool"];

            if (id.HasValue && id.Value > 0)
            {
                ViewBag.Id = id.Value;
                ViewBag.Name = name;
                ViewBag.Address = address;
                ViewBag.Phone = phone;
                ViewBag.WorkingHours = workingHours;
                ViewBag.HasPool = hasPoolForm == "true" ? "Да" : "Нет";

                return View("Result");
            }

            return RedirectToAction("Index");
        }
    }
}