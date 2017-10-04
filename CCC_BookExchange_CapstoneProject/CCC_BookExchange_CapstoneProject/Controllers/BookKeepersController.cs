using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CCC_BookExchange_CapstoneProject.Models;

namespace CCC_BookExchange_CapstoneProject.Controllers
{
    public class BookKeepersController : Controller
    {
        private BooksDBContext db = new BooksDBContext();

        // GET: BookKeepers
        public ActionResult Index()
        {
            //return View(db.book.ToList());
            return View();
        }

        // GET: BookKeepers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookKeeper bookKeeper = db.book.Find(id);
            if (bookKeeper == null)
            {
                return HttpNotFound();
            }
            return View(bookKeeper);
        }

        // GET: BookKeepers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookKeepers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Author,ReleaseDate,Genre,ISBN10,ISBN13,Available")] BookKeeper bookKeeper)
        {
            if (ModelState.IsValid)
            {
                db.book.Add(bookKeeper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookKeeper);
        }

        // GET: BookKeepers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookKeeper bookKeeper = db.book.Find(id);
            if (bookKeeper == null)
            {
                return HttpNotFound();
            }
            return View(bookKeeper);
        }

        // POST: BookKeepers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Author,ReleaseDate,Genre,ISBN10,ISBN13,Available")] BookKeeper bookKeeper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookKeeper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookKeeper);
        }

        // GET: BookKeepers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookKeeper bookKeeper = db.book.Find(id);
            if (bookKeeper == null)
            {
                return HttpNotFound();
            }
            return View(bookKeeper);
        }

        // POST: BookKeepers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookKeeper bookKeeper = db.book.Find(id);
            db.book.Remove(bookKeeper);
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
