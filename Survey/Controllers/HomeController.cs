using Microsoft.AspNet.Identity;
using Microsoft.JScript;
using Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Survey.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public int countAllSurvey;
        public int countAllSurveyAnswered;
        public int countAllSurveyComplete;

        public ActionResult Index()
        {
            countAllSurvey = db.Surveys.Count();
            countAllSurveyComplete = db.Surveys.Where(c => c.Status == SurveyStatus.DONE).Count();




            if (User.Identity.GetUserId() != null)
            {
                var uid = User.Identity.GetUserId();
                var count = db.Account_answers.Where(a => a.Id == uid).GroupBy(a => a.SurveyId).Count();
            }
            else
            {
                countAllSurveyAnswered = 0;
            }

            ViewBag.AllSurvey = countAllSurvey;
            ViewBag.AllSurveyAnswered = countAllSurveyAnswered;
            ViewBag.AllSurveyComplete = countAllSurveyComplete;
            

            return View();
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
        //protected override void Initialize(RequestContext requestContext)
        //{
        //    countAllSurvey = db.Surveys.Count();
        //    countAllSurveyComplete = db.Surveys.Where(c => c.Status == SurveyStatus.DONE).Count();
        //    if (User != null)
        //    {
        //        countAllSurveyAnswered = db.Account_answers.Where(a => a.Id == User.Identity.GetUserId()).Distinct().Count();
        //    }
        //    else
        //    {
        //        countAllSurveyAnswered = 0;
        //    }
        //}
    }
}