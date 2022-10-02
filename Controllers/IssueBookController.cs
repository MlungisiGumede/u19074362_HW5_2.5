using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u19074362_HW5_2._5.Models;

namespace u19074362_HW5_2._5.Content
{
    public class issuebookController : Controller
    {


        libraydatabaseEntities db = new libraydatabaseEntities();
        // GET: issuebook
        public ActionResult Index()
        {
            return View();
        }





        [HttpGet]
        public ActionResult GetBook()
        {

            var books = db.books.Select(p => new

            {

                ID = p.id,
                Bname = p.bname


            }).ToList(); 

            return Json(books, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public ActionResult GetMid(int mid)
        {

            var memberid = (from s in db.members where s.id == mid select s.name).ToList();

            return Json(memberid, JsonRequestBehavior.AllowGet);

            
        }





        [HttpPost]
        public ActionResult Save(issuebook issue)
        {



            if (ModelState.IsValid)
            {
                db.issuebooks.Add(issue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(issue);

        }



    }
}