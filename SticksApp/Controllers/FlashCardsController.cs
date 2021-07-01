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
    public class FlashCardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FlashCards
        public ActionResult Index()
        {
            return View(db.FlashCards.ToList());
        }

        //GET: FlashCards/language
        [HttpGet, Route("FlashCards/GetFlashCardsByTechnology/{language}")]
        public ActionResult GetFlashCardsByTechnology(string language)
        {
            var flashCardsList = db.FlashCards.ToList().Where(x => x.Language == language);
            var maxRandom = flashCardsList.Count();
            Random rnd = new Random();

            return View(flashCardsList.ElementAt(rnd.Next(0,maxRandom)));
        }

        public ActionResult LoadGrid(int currentId, string language)
        {
            UpdateAndGetAnother(currentId);
            var flashCardsList = db.FlashCards.ToList().Where(x => x.Language == language);
            var maxRandom = flashCardsList.Count();
            Random rnd = new Random();
            var model = flashCardsList.ElementAt(rnd.Next(0, maxRandom));
            return PartialView("_CardValues", model);
        }

        public void UpdateAndGetAnother(int currentId)
        {
            var result = db.FlashCards.SingleOrDefault(b => b.Id == currentId);
            if (result != null)
            {
                result.Level= 2;
                db.SaveChanges();
            }
        }
        // GET: FlashCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlashCard flashCard = db.FlashCards.Find(id);
            if (flashCard == null)
            {
                return HttpNotFound();
            }
            return View(flashCard);
        }

        // GET: FlashCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlashCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Question,Answer,Level,Language")] FlashCard flashCard)
        {
            if (ModelState.IsValid)
            {
                db.FlashCards.Add(flashCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flashCard);
        }

        // GET: FlashCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlashCard flashCard = db.FlashCards.Find(id);
            if (flashCard == null)
            {
                return HttpNotFound();
            }
            return View(flashCard);
        }

        // POST: FlashCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Question,Answer")] FlashCard flashCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flashCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flashCard);
        }

        // GET: FlashCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlashCard flashCard = db.FlashCards.Find(id);
            if (flashCard == null)
            {
                return HttpNotFound();
            }
            return View(flashCard);
        }

        // POST: FlashCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlashCard flashCard = db.FlashCards.Find(id);
            db.FlashCards.Remove(flashCard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
