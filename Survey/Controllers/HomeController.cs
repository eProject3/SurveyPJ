using Microsoft.AspNet.Identity;
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

        [Authorize]
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
        [Authorize]
        [HttpPost]
        public ActionResult SaveAnswer()
        {
            var currentSurveyId = HttpContext.Request.Form["currentsurvey"];
            AllSurvey survey = db.Surveys.Where(i => i.SurveyId.ToString() == currentSurveyId).FirstOrDefault();
            var accountId = User.Identity.GetUserId();
            foreach (var item in survey.Questions)
            {

                if (item.Type == 0)
                {

                    var a = HttpContext.Request.Form[item.Id.ToString()];
                    int qId = db.Question_answers.Where(q => q.QuestionId == item.Id).ToList().Where(d => d.Answer == a).FirstOrDefault().QuestionAnswerId;
                    AccountAnswer answer = new AccountAnswer
                    {
                        SurveyId = survey.SurveyId,
                        Id = accountId,
                        QuestionAnswerId = qId,
                        Status = 1,
                        Description = HttpContext.Request.Form[item.Id.ToString()]

                    };
                    db.Account_answers.Add(answer);

                }

                if (item.Type == 1)
                {
                    string a = HttpContext.Request.Form[item.Id.ToString()];
                    int qId = db.Question_answers.Where(q => q.QuestionId == item.Id).ToList().Where(d => d.Answer == a).FirstOrDefault().QuestionAnswerId;
                    AccountAnswer answer = new AccountAnswer
                    {
                        SurveyId = survey.SurveyId,
                        Id = accountId,
                        QuestionAnswerId = qId,
                        Status = 1,
                        Description = HttpContext.Request.Form[item.Id.ToString()]
                    };
                    db.Account_answers.Add(answer);


                }
                if (item.Type == 2)
                {
                    List<String> listAnswer = HttpContext.Request.Form[item.Id.ToString()].Split(',').ToList();

                    foreach (var a in listAnswer)
                    {
                        int qId = db.Question_answers.Where(q => q.QuestionId == item.Id).ToList().Where(d => d.Answer == a).FirstOrDefault().QuestionAnswerId;
                        AccountAnswer answer = new AccountAnswer
                        {
                            SurveyId = survey.SurveyId,
                            Id = accountId,
                            QuestionAnswerId = qId,
                            Status = 1,
                            Description = a

                        };
                        db.Account_answers.Add(answer);

                    }

                }
                if (item.Type == 3)
                {

                    List<String> listAnswer = HttpContext.Request.Form[item.Id.ToString()].Split(',').ToList();
                    if (listAnswer[0] == "Other")
                    {
                        int qId = db.Question_answers.Where(q => q.QuestionId == item.Id).ToList().Where(d => d.Answer == "Other").FirstOrDefault().QuestionAnswerId;
                        AccountAnswer answer = new AccountAnswer
                        {

                            SurveyId = survey.SurveyId,
                            Id = accountId,
                            QuestionAnswerId = qId,
                            Status = 1,
                            Description = listAnswer[1]

                        };
                        db.Account_answers.Add(answer);
                    }
                    if (listAnswer[0] != "Other")
                    {
                        var des = listAnswer[0];
                        int qId = db.Question_answers.Where(q => q.QuestionId == item.Id).ToList().Where(d => d.Answer == des).FirstOrDefault().QuestionAnswerId;
                        AccountAnswer answer = new AccountAnswer
                        {
                            SurveyId = survey.SurveyId,
                            Id = accountId,
                            QuestionAnswerId = qId,
                            Status = 1,
                            Description = des
                        };
                        db.Account_answers.Add(answer);
                    }

                }
                if (item.Type == 4)
                {

                    int qId = db.Question_answers.Where(q => q.QuestionId == item.Id).ToList().Where(d => d.Answer == "Essey").FirstOrDefault().QuestionAnswerId;
                    AccountAnswer answer = new AccountAnswer
                    {
                        SurveyId = survey.SurveyId,
                        Id = accountId,
                        QuestionAnswerId = qId,
                        Status = 1,
                        Description = HttpContext.Request.Form[item.Id.ToString()]
                    };
                    db.Account_answers.Add(answer);
                }
                db.SaveChanges();

            }
            return Redirect("~/Home/Survey");


        }





    }
}