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
    public class Category_tableController : Controller
    {
        private libraydatabaseEntities db = new libraydatabaseEntities();

        // GET: Category_table
        public ActionResult Index()
        {
            return View(db.Category_tables.ToList());
        }

        // GET: Category_table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_table category_table = db.Category_tables.Find(id);
            if (category_table == null)
            {
                return HttpNotFound();
            }
            return View(category_table);
        }

        // GET: Category_table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category_table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,catname,status")] Category_table category_table)
        {
            if (ModelState.IsValid)
            {
                db.Category_tables.Add(category_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category_table);
        }

        // GET: Category_table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_table category_table = db.Category_tables.Find(id);
            if (category_table == null)
            {
                return HttpNotFound();
            }
            return View(category_table);
        }

        // POST: Category_table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,catname,status")] Category_table category_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category_table);
        }

        // GET: Category_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_table category_table = db.Category_tables.Find(id);
            if (category_table == null)
            {
                return HttpNotFound();
            }
            return View(category_table);
        }

        // POST: Category_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category_table category_table = db.Category_tables.Find(id);
            db.Category_tables.Remove(category_table);
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
