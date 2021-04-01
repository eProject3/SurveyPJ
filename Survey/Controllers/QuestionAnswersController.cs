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
            return View();
        }

        // POST: QuestionAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(BigModel bigModels)
        {

            // Loop and insert records.


            foreach (var allSurvey in bigModels.AllSurvey)
            {
                allSurvey.Status = SurveyStatus.NOT_HAPPENNING_YET;
                allSurvey.CreateDate = DateTime.Now;
                allSurvey.UpdateDate = DateTime.Now;
                db.Surveys.Add(allSurvey);
                foreach (var question in bigModels.Question)
                {
                    question.SurveyId = allSurvey.SurveyId;
                    db.Questions.Add(question);

                    foreach (var questionAnswer in bigModels.QuestionAnswer)
                    {
                        questionAnswer.QuestionId = question.Id;
                        db.Question_answers.Add(questionAnswer);
                    }
                }
            }
            db.SaveChanges();

            return RedirectToAction("Index");


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
