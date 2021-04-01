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
        public ActionResult Index()
        {
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



        public ActionResult SurveyDetails()
        {
            //var survey = db.Surveys.Where(p => p.SurveyId == id).ToList();
            //List<Question> listQuestion = db.Questions.Where(p => p.SurveyId == id).ToList();

            //foreach (Question q in listQuestion)
            //{
            //    List<QuestionAnswer> listQuestionAnswer = db.Question_answers.Where(p => p.QuestionId == q.Id).ToList();
            //    q.QuestionAnswers = listQuestionAnswer;
            //    ViewBag.Answer = listQuestionAnswer;
            //};
            //ViewBag.Question = listQuestion;
            //ViewBag.Survey = survey;





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