using System.Linq;
using System.Web.Mvc;
using fitness_centersApp.Models;

namespace fitness_centersApp.Controllers
{
    public class FitnessController : Controller
    {
        public ActionResult ListAll()
        {
            ViewData["UseInternalHelper"] = false;
            return View(FitnessStorage.Centers);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("ListAll");
            }

            for (int i = 0; i < FitnessStorage.Centers.Length; i++)
            {
                if (FitnessStorage.Centers[i].Id == id.Value)
                {
                    Session["CurrentCenterId"] = id.Value;
                    return View(FitnessStorage.Centers[i]);
                }
            }
            return RedirectToAction("ListAll");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new FitnessCenter());
        }

        [HttpPost]
        public ActionResult Create(FitnessCenter model)
        {
            if (ModelState.IsValid)
            {
                model.Id = FitnessStorage.Centers.Length == 0
                    ? 1
                    : FitnessStorage.Centers.Max(c => c.Id) + 1;

                FitnessCenter[] newArray = new FitnessCenter[FitnessStorage.Centers.Length + 1];
                for (int i = 0; i < FitnessStorage.Centers.Length; i++)
                {
                    newArray[i] = FitnessStorage.Centers[i];
                }
                newArray[FitnessStorage.Centers.Length] = model;
                FitnessStorage.Centers = newArray;

                return RedirectToAction("ListAll");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("ListAll");
            }

            FitnessCenter center = FindById(id.Value);
            if (center == null)
            {
                return RedirectToAction("ListAll");
            }

            Session["CurrentCenterId"] = id.Value;
            return View(center);
        }

        [HttpPost]
        public ActionResult Edit(FitnessCenter model)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < FitnessStorage.Centers.Length; i++)
                {
                    if (FitnessStorage.Centers[i].Id == model.Id)
                    {
                        FitnessStorage.Centers[i] = model;
                        break;
                    }
                }
                return RedirectToAction("ListAll");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            int deleteIndex = -1;
            for (int i = 0; i < FitnessStorage.Centers.Length; i++)
            {
                if (FitnessStorage.Centers[i].Id == id)
                {
                    deleteIndex = i;
                    break;
                }
            }

            if (deleteIndex != -1)
            {
                FitnessCenter[] newArray = new FitnessCenter[FitnessStorage.Centers.Length - 1];
                int newIndex = 0;
                for (int i = 0; i < FitnessStorage.Centers.Length; i++)
                {
                    if (i != deleteIndex)
                    {
                        newArray[newIndex++] = FitnessStorage.Centers[i];
                    }
                }
                FitnessStorage.Centers = newArray;
            }

            return RedirectToAction("ListAll");
        }

        private FitnessCenter FindById(int id)
        {
            for (int i = 0; i < FitnessStorage.Centers.Length; i++)
            {
                if (FitnessStorage.Centers[i].Id == id)
                {
                    return FitnessStorage.Centers[i];
                }
            }
            return null;
        }
    }
}