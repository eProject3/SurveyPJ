using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Survey.Models;

namespace Survey.Controllers
{
    public class QuestionAnswersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QuestionAnswers
        public ActionResult Index()
        {

            var question_answers = db.Question_answers.Include(q => q.Question);
            return View(question_answers.ToList());
        }

        // GET: QuestionAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswer questionAnswer = db.Question_answers.Find(id);
            if (questionAnswer == null)
            {
                return HttpNotFound();
            }
            return View(questionAnswer);
        }

        // GET: QuestionAnswers/Create
        public ActionResult Create()
        {

            List<BigModel> ci = new List<BigModel> { new BigModel 
            { 
                AllSurvey = new AllSurvey {

                }, 
                Question = new Question { 
                }, 
                QuestionAnswer = new QuestionAnswer {

                } } };
            ViewBag.SurveyId = new SelectList(db.Surveys, "SurveyId", "Title");
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Title");
            return View(ci);
        }

        // POST: QuestionAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(List<BigModel> bigModel)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var i in bigModel)
                    {
                        if(i.AllSurvey != null)
                        {
                            i.AllSurvey.Status = SurveyStatus.NOT_HAPPENNING_YET;
                            i.AllSurvey.CreateDate = DateTime.Now;
                            i.AllSurvey.UpdateDate = DateTime.Now;
                            db.Surveys.Add(i.AllSurvey);
                        }
                        
                    }
                    
                    db.SaveChanges();

                    // throw exectiopn to test roll back transaction
                    for (var i =0; i<bigModel.Count(); i++)
                    {
                        if (i > 0)
                        {
                            bigModel[i].AllSurvey = bigModel[i - 1].AllSurvey;
                        }
                        bigModel[i].Question.SurveyId = bigModel[i].AllSurvey.SurveyId;
                        db.Questions.Add(bigModel[i].Question);
                    }
                    db.SaveChanges();

                    // throw exectiopn to test roll back transaction
                    foreach (var i in bigModel)
                    {
                        i.QuestionAnswer.QuestionId = i.Question.Id;
                        db.Question_answers.Add(i.QuestionAnswer);
                    }
                    db.SaveChanges();

                    transaction.Commit();
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex);
                }
                return null;
            }            
        }
        // GET: QuestionAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswer questionAnswer = db.Question_answers.Find(id);
            if (questionAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Title", questionAnswer.QuestionId);
            return View(questionAnswer);
        }

        // POST: QuestionAnswers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionAnswerId,Answer,QuestionId")] QuestionAnswer questionAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Title", questionAnswer.QuestionId);
            return View(questionAnswer);
        }

        // GET: QuestionAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswer questionAnswer = db.Question_answers.Find(id);
            if (questionAnswer == null)
            {
                return HttpNotFound();
            }
            return View(questionAnswer);
        }

        // POST: QuestionAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionAnswer questionAnswer = db.Question_answers.Find(id);
            db.Question_answers.Remove(questionAnswer);
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
