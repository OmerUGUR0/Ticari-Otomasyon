﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticari_Otomasyon.Models.Classes;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Currents.Count().ToString();
            ViewBag.d1 = value1;

            var value2 = c.Products.Count().ToString();
            ViewBag.d2 = value2;

            var value3 = c.Personnels.Count().ToString();
            ViewBag.d3 = value3;

            var value4 = c.Categories.Count().ToString();
            ViewBag.d4 = value4;

            var value5 = c.Products.Sum(x=>x.Stock).ToString();
            ViewBag.d5 = value5;

            var value6 = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = value6;

            var value7 = c.Products.Count(x=>x.Stock<=20).ToString();
            ViewBag.d7 = value7;

            var value8 = (from x in c.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = value8;

            var value9 = (from x in c.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = value9;

            var value10= c.Products.Count(x => x.ProductName=="Buzdolabı").ToString();
            ViewBag.d10 = value10;

            var value11 = c.Products.Count(x => x.ProductName == "Leptop").ToString();
            ViewBag.d11 = value11;

            var value12 = c.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = value12;

            var value13 = c.Products.Where(u=>u.ProductID==( c.SalesMovements.GroupBy(x => x.Productid).OrderByDescending
            (z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.d13 = value13;

            var value14 = c.SalesMovements.Sum(x => x.TotalAmount).ToString();
            ViewBag.d14 = value14;

            DateTime today = DateTime.Today;
            var value15 = c.SalesMovements.Count(x => x.Date== today).ToString();
            ViewBag.d15 = value15;

            //var value16 = c.SalesMovements.Where(x => x.Date == today).Sum(y => y.TotalAmount).ToString();
            //ViewBag.d16 = value16;









            return View();
        }

    }
}