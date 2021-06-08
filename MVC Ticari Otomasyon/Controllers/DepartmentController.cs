using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticari_Otomasyon.Models.Classes;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Departments.Where(x => x.Status == true).ToList();
            return View(value);
        }
        [HttpPost]
        public ActionResult DepartmentAdd(Department d)
        {
            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DepartmentAdd()
        {
            return View();
        }
        public ActionResult DepartmentDelete(int id)
        {
            var value = c.Departments.Find(id);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentBring(int id)
        {
            var value = c.Departments.Find(id);
            return View("DepartmentBring", value);
        }
        public ActionResult DepartmentUpdate (Department p)
        {
            var value = c.Departments.Find(p.DepartmentId);
            value.DepartmentName = p.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDetail(int id)
        {
            var value = c.Personnels.Where(x => x.Departmentid == id).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;
            return View(value);
        }
        public ActionResult DepartmentPersonnelSales(int id)
        {
            var value = c.SalesMovements.Where(x => x.Personnelid == id).ToList();
            var per = c.Personnels.Where(x => x.PersonnelID == id).Select(y => y.PersonnelName +" "+ y.PersonnelSurName).FirstOrDefault();
            ViewBag.dpers = per;
            return View(value);
        }
        
    }
}