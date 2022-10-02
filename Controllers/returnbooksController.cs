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
    public class returnbooksController : Controller
    {
        private libraydatabaseEntities db = new libraydatabaseEntities();

        // GET: returnbooks
        public ActionResult Index()
        {
            return View(db.returnbooks.ToList());
        }

        // GET: returnbooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            returnbook returnbook = db.returnbooks.Find(id);
            if (returnbook == null)
            {
                return HttpNotFound();
            }
            return View(returnbook);
        }

        // GET: returnbooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: returnbooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,mid,book,returndate,elap,fine")] returnbook returnbook)
        {
            if (ModelState.IsValid)
            {
                db.returnbooks.Add(returnbook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(returnbook);
        }

        // GET: returnbooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            returnbook returnbook = db.returnbooks.Find(id);
            if (returnbook == null)
            {
                return HttpNotFound();
            }
            return View(returnbook);
        }

        // POST: returnbooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,mid,book,returndate,elap,fine")] returnbook returnbook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(returnbook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(returnbook);
        }

        // GET: returnbooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            returnbook returnbook = db.returnbooks.Find(id);
            if (returnbook == null)
            {
                return HttpNotFound();
            }
            return View(returnbook);
        }

        // POST: returnbooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            returnbook returnbook = db.returnbooks.Find(id);
            db.returnbooks.Remove(returnbook);
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
