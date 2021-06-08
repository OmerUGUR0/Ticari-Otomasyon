using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticari_Otomasyon.Models.Classes;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Currents.Where(x => x.Status == true).ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CurrentAdd()
        {
            return View();
        }
        public ActionResult CurrentAdd(Current p)
        {
            p.Status = true;
            c.Currents.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentDelete(int id)
        {
            var value = c.Currents.Find(id);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentBring(int id)
        {
            var value = c.Currents.Find(id);
            return View("CurrentBring", value);
        }
        public ActionResult CurrentUpdate(Current p)
        {
            if (!ModelState.IsValid)
            {
                return View("CurrentBring");
            }
            var value = c.Currents.Find(p.CurrentID);
            value.CurrentName = p.CurrentName;
            value.CurrentSurName = p.CurrentSurName;
            value.CurrentCity = p.CurrentCity;
            value.CurrentMail = p.CurrentMail;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CustomerSales(int id)
        {
            var value = c.SalesMovements.Where(x => x.Currentid == id).ToList();
            var cr = c.Currents.Where(x => x.CurrentID == id).Select(y => y.CurrentName + " " + y.CurrentSurName).FirstOrDefault();
            ViewBag.cari = cr;
            return View(value);
        }
    }
}