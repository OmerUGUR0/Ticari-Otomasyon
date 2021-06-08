using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticari_Otomasyon.Models.Classes;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product // ÜRÜN
        Context c = new Context();
        public ActionResult Index()
        {
            var Products = c.Products.Where(x => x.Status == true).ToList();
            return View(Products);
        }
        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryAd,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();
            ViewBag.vlue = value1;
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductDelete(int id)
        {
            var value = c.Products.Find(id);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductBring(int id)
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryAd,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.vlue = value1;
            var productvalue = c.Products.Find(id);
            return View("ProductBring", productvalue);
        }
        public ActionResult ProductUpdate(Product p)
        {
            var value = c.Products.Find(p.ProductID);
            value.ProductName = p.ProductName;
            value.Brand = p.Brand;
            value.Stock = p.Stock;
            value.PurchasePrice = p.PurchasePrice;
            value.SalePrice = p.SalePrice;
            value.SalePrice = p.SalePrice;
            value.Status = p.Status;
            value.ProductImage = p.ProductImage;
            value.Categoryid = p.Categoryid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList()
        {
            var value = c.Products.ToList();
            return View(value);
        }
    }
}