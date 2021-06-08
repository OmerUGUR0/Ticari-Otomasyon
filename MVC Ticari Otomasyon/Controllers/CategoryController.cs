using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticari_Otomasyon.Models.Classes;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        // Kategori Controller

        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Categories.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryDelete(int id)
        {
            var ctgry = c.Categories.Find(id);
            c.Categories.Remove(ctgry);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryBring(int id)
        {
            var ctg = c.Categories.Find(id);

            return View("CategoryBring", ctg);
        }
        public ActionResult CategoryUpdate(Category k)
        {
            var ctgry = c.Categories.Find(k.CategoryID);
            ctgry.CategoryAd = k.CategoryAd;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}