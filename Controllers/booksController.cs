using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using u19074362_HW5_2._5.Models;

namespace u19074362_HW5_2._5.Controllers
{
    public class booksController : Controller
    {
        private libraydatabaseEntities db = new libraydatabaseEntities();

        // GET: books
        public ActionResult Index()
        {
            var books = db.books.Include(b => b.author).Include(b => b.Category_table).Include(b => b.publisher);
            return View(books.ToList());
        }

        // GET: books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: books/Create
        public ActionResult Create()
        {
            ViewBag.auth_id = new SelectList(db.authors, "id", "name");
            ViewBag.cat_id = new SelectList(db.Category_tables, "id", "catname");
            ViewBag.pub_id = new SelectList(db.publishers, "id", "name");
            return View();
        }

        // POST: books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bname,cat_id,auth_id,pub_id,contents,pages,edition")] book book)
        {
            if (ModelState.IsValid)
            {
                db.books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.auth_id = new SelectList(db.authors, "id", "name", book.auth_id);
            ViewBag.cat_id = new SelectList(db.Category_tables, "id", "catname", book.cat_id);
            ViewBag.pub_id = new SelectList(db.publishers, "id", "name", book.pub_id);
            return View(book);
        }

        // GET: books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.auth_id = new SelectList(db.authors, "id", "name", book.auth_id);
            ViewBag.cat_id = new SelectList(db.Category_tables, "id", "catname", book.cat_id);
            ViewBag.pub_id = new SelectList(db.publishers, "id", "name", book.pub_id);
            return View(book);
        }

        // POST: books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bname,cat_id,auth_id,pub_id,contents,pages,edition")] book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.auth_id = new SelectList(db.authors, "id", "name", book.auth_id);
            ViewBag.cat_id = new SelectList(db.Category_tables, "id", "catname", book.cat_id);
            ViewBag.pub_id = new SelectList(db.publishers, "id", "name", book.pub_id);
            return View(book);
        }

        // GET: books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book book = db.books.Find(id);
            db.books.Remove(book);
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
