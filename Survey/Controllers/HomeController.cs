using Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Survey.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(Support support)
        {
            var totalSurvey = db.Surveys.ToList().Count();
            ViewBag.totalSurvey = totalSurvey;

            //var totaStudent = db.A.Where(x => x.Location.Equals("Europe")).Count();
            //ViewBag.europe = europe;

            //var africa = db.Example.Where(x => x.Location.Equals("Africa")).Count();
            //ViewBag.africa = africa;
            return View(support);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FAQHome()
        {

            return View(db.FAQs.ToList());
        }
        public ActionResult SupportHome()
        {

            return View(db.Supports.ToList());
        }

        public ActionResult Survey()
        {
            return View(db.Surveys.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllSurvey allSurvey = db.Surveys.Find(id);
            if (allSurvey == null)
            {
                return HttpNotFound();
            }
            return View(allSurvey);
        }


        

    }
}