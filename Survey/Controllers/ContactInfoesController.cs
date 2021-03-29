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
    public class ContactInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult BulkData()
        {
            // This is only for show by default one row for insert data to the database
            List<ContactInfo> ci = new List<ContactInfo> { new ContactInfo { ID = 0, ContactName = "", ContactNo = "" } };
            return View(ci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BulkData(List<ContactInfo> ci)
        {
            if (ModelState.IsValid)
            {
                
                    foreach (var i in ci)
                    {
                        db.ContactInfoes.Add(i);
                    }
                db.SaveChanges();
                    ViewBag.Message = "Data successfully saved!";
                    ModelState.Clear();
                    ci = new List<ContactInfo> { new ContactInfo { ID = 0, ContactName = "", ContactNo = "" } };
                
            }
            return View(ci);
        }


        // GET: ContactInfoes
        public ActionResult Index()
        {
            return View(db.ContactInfoes.ToList());
        }

        // GET: ContactInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInfo contactInfo = db.ContactInfoes.Find(id);
            if (contactInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactInfo);
        }

        // GET: ContactInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ContactName,ContactNo")] ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                db.ContactInfoes.Add(contactInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactInfo);
        }

        // GET: ContactInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInfo contactInfo = db.ContactInfoes.Find(id);
            if (contactInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactInfo);
        }

        // POST: ContactInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ContactName,ContactNo")] ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactInfo);
        }

        // GET: ContactInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInfo contactInfo = db.ContactInfoes.Find(id);
            if (contactInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactInfo);
        }

        // POST: ContactInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactInfo contactInfo = db.ContactInfoes.Find(id);
            db.ContactInfoes.Remove(contactInfo);
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
