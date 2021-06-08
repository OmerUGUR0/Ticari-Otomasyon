using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticari_Otomasyon.Models.Classes;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Invoices.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult InvoiceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InvoiceAdd(Invoice p)
        {
            var value = c.Invoices.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InvoiceBring(int id)
        {
            var value = c.Invoices.Find(id);
            return View("InvoiceBring", value);
        }
        public ActionResult InvoiceUpdate(Invoice p)
        {
            var value = c.Invoices.Find(p.InvoiceId);

            value.InvoicetSerialNumber = p.InvoicetSerialNumber;
            value.InvoicetRowNumber = p.InvoicetRowNumber;
            value.TaxAdministr = p.TaxAdministr;
            value.InvoicetDate = p.InvoicetDate;
            value.Hour = p.Hour;
            value.Delivering = p.Delivering;
            value.Receive = p.Receive;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InvoiceDetail(int id)
        {
            var value = c.InvoiceItems.Where(x => x.Invoiceid == id).ToList();        
            return View(value);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(InvoiceItem p)
        {
            c.InvoiceItems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}