using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookExchange3.Models;

namespace BookExchange3.Controllers
{
    public class ReservesController : Controller
    {
        private BooksDbContext db = new BooksDbContext();

        // GET: Reserves
        public ActionResult Index()
        {
            return View(db.Reserves.ToList());
        }
        
        // GET: Reserves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserve reserve = db.Reserves.Find(id);
            if (reserve == null)
            {
                return HttpNotFound();
            }
            return View(reserve);
        }

        //public ActionResult RequestConfirmation()
        //{
        //    ViewBag.Message = DateTime.Now.AddDays(3);
        //    return View();
        //}

        // GET: Reserves/Create
        public ActionResult Confirmed()
        {
            return View();
           
        }

        public ActionResult Reserve()
        {
            
            
            return View();
        }

        // POST: Reserves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reserve([Bind(Include = "ID,FirstName,LastName,PhoneNumber,Email, book")] Reserve reserve, int id)
        {
            //reserve.book = id;
            if (ModelState.IsValid)
            {
               var bookReserved = db.Books.Where(i => i.ID == id).First();
                var quearyTemp = from m in db.Books
                                 where m.ID == id
                                 select m;

                foreach (Books m in quearyTemp)
                {
                    m.Available = false;
                }

                reserve.book = bookReserved;
                reserve.ReserveBeginDate = DateTime.Now;
                reserve.ReserveEndDate = DateTime.Now.AddDays(3);

                int x = reserve.ID;
                
                db.Reserves.Add(reserve);
                db.SaveChanges();
                return RedirectToAction("Confirmed");
            }

            return View(reserve);
        }

        // GET: Reserves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserve reserve = db.Reserves.Find(id);
            if (reserve == null)
            {
                return HttpNotFound();
            }
            return View(reserve);
        }

        

        // POST: Reserves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,PhoneNumber,Email")] Reserve reserve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reserve);
        }

        // GET: Reserves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserve reserve = db.Reserves.Find(id);
            if (reserve == null)
            {
                return HttpNotFound();
            }
            return View(reserve);
        }

        // POST: Reserves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserve reserve = db.Reserves.Find(id);
            db.Reserves.Remove(reserve);
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
