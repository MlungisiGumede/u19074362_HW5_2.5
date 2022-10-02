using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u19074362_HW5_2._5.Models;

namespace u19074362_HW5_2._5.Controllers
{
    public class ReturnController : Controller
    {
        // GET: Return

        private libraydatabaseEntities db = new libraydatabaseEntities();


        public ActionResult Index()
        {
            return View();
        }




        public ActionResult GetMid(int mid)
        {



            var memberid = (from s in db.issuebooks
                            where s.m_id == mid


                            select new
                            {

                                issueDate = s.issuedate,

                                returnDate = s.returndate,
                                Memberid = s.m_id,
                                BookName = s.book_id,
                                ElapseDays = SqlFunctions.DateDiff("day", s.returndate, DateTime.Now)

                            }).ToArray();

            return Json(memberid, JsonRequestBehavior.AllowGet);
        }




    }

  /*  [HttpPost]
    public ActionResult Save(returnbook returnbook)
    {



        if (ModelState.IsValid)
        {
            object db = null;
            db.returnbook.Add(returnbook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(issue);

    }*/


}