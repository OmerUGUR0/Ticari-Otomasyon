using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticari_Otomasyon.Models.Classes;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.SalesMovements.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult newSales()
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();
            List<SelectListItem> value2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurName,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in c.Personnels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonnelName + " " + x.PersonnelSurName,
                                               Value = x.PersonnelID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = value3;
            ViewBag.dgr2 = value2;
            ViewBag.dgr1 = value1;
            return View();
        }
        [HttpPost]
        public ActionResult newSales(SalesMovement s)
        {
            s.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMovements.Add(s);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult SalesBring(int id)
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();
            List<SelectListItem> value2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurName,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in c.Personnels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonnelName + " " + x.PersonnelSurName,
                                               Value = x.PersonnelID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = value3;
            ViewBag.dgr2 = value2;
            ViewBag.dgr1 = value1;
            var value = c.SalesMovements.Find(id);
            return View("SalesBring", value);

        }
        public ActionResult SalesUpdate(SalesMovement p)
        {
            var value = c.SalesMovements.Find(p.SalesMovementID);
            value.Currentid = p.Currentid;
            value.Piece = p.Piece;
            value.Price = p.Price;
            value.Personnelid = p.Personnelid;
            value.Date = p.Date;
            value.TotalAmount = p.TotalAmount;
            value.Productid = p.Productid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesDetail(int id)
        {
            var value = c.SalesMovements.Where(x => x.Personnelid == id).ToList();
            return View(value);
        }


    }
}