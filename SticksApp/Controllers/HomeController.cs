using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SticksApp.Models;

namespace SticksApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewData["CsharpProgrsss"] = db.FlashCards.ToList().Where(x => x.Language == "Csharp").Where(x => x.Level == 9).Count();
            ViewData["CsharpCount"] = db.FlashCards.Where(x => x.Language == "Csharp").Count();

            ViewData["JSProgrsss"] = db.FlashCards.ToList().Where(x => x.Language == "JS").Where(x => x.Level == 9).Count();
            ViewData["JSCount"] = db.FlashCards.Where(x => x.Language == "JS").Count();

            ViewData["PythonProgress"] = db.FlashCards.ToList().Where(x => x.Language == "Python").Where(x => x.Level == 9).Count();
            ViewData["PythonCount"] = db.FlashCards.Where(x => x.Language == "Python").Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}