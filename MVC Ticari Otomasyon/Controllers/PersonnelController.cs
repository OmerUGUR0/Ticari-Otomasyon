using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticari_Otomasyon.Models.Classes;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class PersonnelController : Controller
    {
        // GET: Personnel
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Personnels.ToList();
            return View(value);
        }
        [HttpPost]
        public ActionResult PersonnelAdd(Personnel p)
        {
            var value = c.Personnels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult PersonnelAdd()
        {
            
            return View();
        }
        public ActionResult PersonnelBring(int id)
        {
            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.vlue = value1;
            var value = c.Personnels.Find(id);        
            return View("PersonnelBring", value);

        }
        public ActionResult PersonnelUpdate(Personnel p)
        {
            var value = c.Personnels.Find(p.PersonnelID);
            value.PersonnelName = p.PersonnelName;
            value.PersonnelSurName = p.PersonnelSurName;
            value.PersonnelImage = p.PersonnelImage;
            value.Departmentid = p.Departmentid;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}