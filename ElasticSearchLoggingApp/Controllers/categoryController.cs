using ElasticSearchLoggingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ElasticSearchLoggingApp.Models;

namespace ElasticSearchLoggingApp.Controllers
{
    public class categoryController : Controller
    {
        DataModel1 db = new DataModel1();
        public ActionResult Index()
        {
            var model = db.categories.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(categories category)
        {
            var x = db.categories.Find(category.id);
            if (x == null)
            {
                db.categories.Add(category);
            }
            else
            {
                if (x == null)
                {
                    HttpNotFound();
                }
                else
                {
                    x.id = category.id;
                    x.name = category.name;
                }
            }
            db.SaveChanges();
            return RedirectToAction("index", "category");
        }
        public ActionResult edit(int id)
        {
            var model = db.categories.Find(id);
            if (model == null)
                HttpNotFound();
            return View("create", model);
        }
    }
}