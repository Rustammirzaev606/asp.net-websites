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
    public class BooksController : Controller
    {
        private BooksDbContext db = new BooksDbContext();

        public BooksController()
        {     


            var quearyTemp1 = from r in db.Reserves
                              where r.ReserveBeginDate.Day - DateTime.Now.Day < -3
                              join b in db.Books
                              on r.ID equals b.ID
                              select b;
            foreach (Books y in quearyTemp1)
            {
                if(y.Taken == false)
                {
                    y.Available = true;
                }
                
            }
            db.SaveChanges();

            var queryTemp2 = from r in db.Reserves
                             where r.ReserveBeginDate.Day - DateTime.Now.Day < -3
                             select r;
            foreach (Reserve u in queryTemp2)
            {
                db.Reserves.Remove(u);
            }



            db.SaveChanges();
        }


        // GET: Books
        [Authorize]
        public ActionResult Index(string searchGenre, string searchAuthor, string searchTitle, string searchISBN)
        {


            var book1 = from m in db.Books
                       select m;

            if (!string.IsNullOrEmpty(searchGenre))
            {
                book1 = book1.Where(s => s.Genre.Contains(searchGenre));
            }

            if (!string.IsNullOrEmpty(searchAuthor))
            {
                book1 = book1.Where(x => x.Author.Contains(searchAuthor));
            }

            if (!string.IsNullOrEmpty(searchTitle))
            {
                book1 = book1.Where(y => y.Title.Contains(searchTitle));
            }

            if (!string.IsNullOrEmpty(searchISBN))
            {
                double searchISBN2;
                Double.TryParse(searchISBN, out searchISBN2);
                book1 = book1.Where(z => z.ISBN == searchISBN2);
            }

            return View(book1);
        }
        public ActionResult ListOfBooks(string searchGenre, string searchAuthor, string searchTitle, string searchISBN)
        {
            

            var book = from m in db.Books
                         select m;

            if (!string.IsNullOrEmpty(searchGenre))
            {
                book = book.Where(s => s.Genre.Contains(searchGenre));
            }

            if (!string.IsNullOrEmpty(searchAuthor))
            {
                book = book.Where(x => x.Author.Contains(searchAuthor));
            }

            if (!string.IsNullOrEmpty(searchTitle))
            {
                book = book.Where(y => y.Title.Contains(searchTitle));
            }

            if (!string.IsNullOrEmpty(searchISBN))
            {
                double searchISBN2;
                Double.TryParse(searchISBN, out searchISBN2);
                book = book.Where(z => z.ISBN == searchISBN2);
            }

            return View(book);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // GET: Books/Create
        public ActionResult Donate()
        {
            return View();
        }

        public ActionResult Confirmation()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Donate([Bind(Include = "ID,Title,Author,Genre,ISBN,Available = false,Taken = false")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(books);
                db.SaveChanges();
                return RedirectToAction("Confirmation");
            }

            return View(books);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Author,Genre,ISBN,Available,Taken")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(books);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Books books = db.Books.Find(id);
            db.Books.Remove(books);
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

        //public ActionResult ListOfBooks()
        //{
        //    return View(db.Books.ToList());
        //}
    }
}
