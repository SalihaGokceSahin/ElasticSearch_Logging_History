using ElasticSearchLoggingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElasticSearchLoggingApp.ViewModel;

namespace ElasticSearchLoggingApp.Controllers
{
    public class productController : Controller
    {
        DataModel1 db = new DataModel1();
        public ActionResult Index()
        {
            var model = db.products.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult create()
        {
            var model = new productViewModel() { category=db.categories.ToList()};
            return View(model);
        }
        [HttpPost]
        public ActionResult create(products product)
        {
            if (product.id == 0)
            {
                db.products.Add(product);
            }
            else
            {
                var x = db.products.Find(product.id);
                if (product.id == 0)
                {
                    HttpNotFound();
                }
                else
                {
                    x.name = product.name;
                    x.categories = product.categories;
                    x.categories_id = product.categories_id;
                    x.categories_id = product.categories_id;
                    x.price = product.price;
                    x.count = product.count;
                }
                
            }
            db.SaveChanges();
            return RedirectToAction("index", "product");
        }
        public ActionResult edit(int id)
        {
            var model = new productViewModel() { 
            category=db.categories.ToList(),
            product=db.products.Find(id)};
            if (model == null)
            {
                HttpNotFound();
            }
            return View("create",model);
        }
    }
}