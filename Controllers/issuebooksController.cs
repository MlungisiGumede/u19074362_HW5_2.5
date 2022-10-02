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
    public class issuebooksController : Controller
    {
        private libraydatabaseEntities db = new libraydatabaseEntities();

        // GET: issuebooks
        public ActionResult Index()
        {
            return View(db.issuebooks.ToList());
        }

        // GET: issuebooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            issuebook issuebook = db.issuebooks.Find(id);
            if (issuebook == null)
            {
                return HttpNotFound();
            }
            return View(issuebook);
        }

        // GET: issuebooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: issuebooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,m_id,book_id,issuedate,returndate")] issuebook issuebook)
        {
            if (ModelState.IsValid)
            {
                db.issuebooks.Add(issuebook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(issuebook);
        }

        // GET: issuebooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            issuebook issuebook = db.issuebooks.Find(id);
            if (issuebook == null)
            {
                return HttpNotFound();
            }
            return View(issuebook);
        }

        // POST: issuebooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,m_id,book_id,issuedate,returndate")] issuebook issuebook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issuebook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(issuebook);
        }

        // GET: issuebooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            issuebook issuebook = db.issuebooks.Find(id);
            if (issuebook == null)
            {
                return HttpNotFound();
            }
            return View(issuebook);
        }

        // POST: issuebooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]




        public ActionResult DeleteConfirmed(int id)
        {
            issuebook issuebook = db.issuebooks.Find(id);
            db.issuebooks.Remove(issuebook);
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
