using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP3MVC.Models;
using Newtonsoft.Json;

namespace ASP3MVC.Controllers
{
    public class DictController : Controller
    {
        DictObjectContext db = new DictObjectContext();
        // GET: Dict
        public ActionResult Index()
        {
            IEnumerable<DictObject> dictObjects = db.GetAll().OrderBy(i=>i.FIO);
            ViewBag.Objects = dictObjects;
            return View();
        }

        // GET: Dict/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Object = db.Find(id);
            return View();
        }

        // GET: Dict/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Dict/Create
        [HttpPost]
        public ActionResult AddSave(DictObject dict)
        {
            try
            {
                // TODO: Add insert logic here
                db.Add(dict);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dict/Update/5
        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Object = db.Find(id);
            return View();
        }
        // POST: Dict/UpdateSave/5
        [HttpPost]
        public ActionResult UpdateSave(DictObject dict)
        {
            try
            {
                // TODO: Add update logic here
                db.Update(dict);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dict/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.Object = db.Find(id);
            return View();
        }

        // POST: Dict/Delete/5
        [HttpPost]
        public ActionResult DeleteSave(DictObject dict)
        {
            try
            {
                // TODO: Add delete logic here
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
