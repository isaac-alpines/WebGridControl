﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGridControl.Models;

namespace WebGridControl.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Kitap.GenerateFakeData(50);

            return View(Kitap.Kitaplar);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            List<Kitap> filtrelenmis =
                Kitap.Kitaplar.Where(x =>
                    x.Adi.ToLower().Contains(search) ||
                    x.Yazar.ToLower().Contains(search) ||
                    x.YayinTarihi.ToString().Contains(search) ||
                    x.Fiyat.ToString().Contains(search)).ToList();

            return View(filtrelenmis);
        }
    }
}