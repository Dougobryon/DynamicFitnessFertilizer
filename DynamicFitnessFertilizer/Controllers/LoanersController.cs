using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DynamicFitnessFertilizer.Models;

namespace DynamicFitnessFertilizer.Controllers
{
    public class LoanersController : Controller
    {
        private DFFDBEntities db = new DFFDBEntities();

        // GET: Loaners
        public ActionResult Index()
        {
            var loaners = db.Loaners.Include(l => l.LawnTool).Include(l => l.Member);
            return View(loaners.ToList());
        }

        // GET: Loaners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaner loaner = db.Loaners.Find(id);
            if (loaner == null)
            {
                return HttpNotFound();
            }
            return View(loaner);
        }

        // GET: Loaners/Create
        public ActionResult Create()
        {
            ViewBag.LawnToolID = new SelectList(db.LawnTools, "LawnToolsID", "ToolName");
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName");
            return View();
        }

        // POST: Loaners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoanerID,MemberID,LawnToolID,DateLoaned")] Loaner loaner)
        {
            if (ModelState.IsValid)
            {
                db.Loaners.Add(loaner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LawnToolID = new SelectList(db.LawnTools, "LawnToolsID", "ToolName", loaner.LawnToolID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName", loaner.MemberID);
            return View(loaner);
        }

        // GET: Loaners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaner loaner = db.Loaners.Find(id);
            if (loaner == null)
            {
                return HttpNotFound();
            }
            ViewBag.LawnToolID = new SelectList(db.LawnTools, "LawnToolsID", "ToolName", loaner.LawnToolID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName", loaner.MemberID);
            return View(loaner);
        }

        // POST: Loaners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoanerID,MemberID,LawnToolID,DateLoaned")] Loaner loaner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LawnToolID = new SelectList(db.LawnTools, "LawnToolsID", "ToolName", loaner.LawnToolID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName", loaner.MemberID);
            return View(loaner);
        }

        // GET: Loaners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaner loaner = db.Loaners.Find(id);
            if (loaner == null)
            {
                return HttpNotFound();
            }
            return View(loaner);
        }

        // POST: Loaners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loaner loaner = db.Loaners.Find(id);
            db.Loaners.Remove(loaner);
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