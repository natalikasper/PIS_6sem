using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ASP3MVC.Models;

namespace ASP3MVC.Controllers
{
    public class DictController : Controller
    {
        DictObjectContext db = new DictObjectContext();
        public ActionResult Index()
        {
            IEnumerable<DictObject> dictObjects = db.GetAll().OrderBy(i=>i.FIO);
            ViewBag.Objects = dictObjects;
            return View();
        }

        public ActionResult Details(int id)
        {
            ViewBag.Object = db.Find(id);
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(DictObject dict)
        {
            try
            {
                db.Add(dict);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Object = db.Find(id);
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSave(DictObject dict)
        {
            try
            {
                db.Update(dict);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.Object = db.Find(id);
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSave(DictObject dict)
        {
            try
            {
                db.Delete(dict.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            ViewBag.Method = Request.HttpMethod;
            ViewBag.URL2 = Request.Url.ToString().Split(';')[1];
            return View();
        }
    }
}
