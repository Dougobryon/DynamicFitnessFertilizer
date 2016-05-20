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
    public class LawnToolsController : Controller
    {
        private DFFDBEntities db = new DFFDBEntities();

        // GET: LawnTools
        public ActionResult Index()
        {
            return View(db.LawnTools.ToList());
        }

        // GET: LawnTools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawnTool lawnTool = db.LawnTools.Find(id);
            if (lawnTool == null)
            {
                return HttpNotFound();
            }
            return View(lawnTool);
        }

        // GET: LawnTools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LawnTools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LawnToolsID,ToolName,ToolBrand")] LawnTool lawnTool)
        {
            if (ModelState.IsValid)
            {
                db.LawnTools.Add(lawnTool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lawnTool);
        }

        // GET: LawnTools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawnTool lawnTool = db.LawnTools.Find(id);
            if (lawnTool == null)
            {
                return HttpNotFound();
            }
            return View(lawnTool);
        }

        // POST: LawnTools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LawnToolsID,ToolName,ToolBrand")] LawnTool lawnTool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lawnTool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lawnTool);
        }

        // GET: LawnTools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawnTool lawnTool = db.LawnTools.Find(id);
            if (lawnTool == null)
            {
                return HttpNotFound();
            }
            return View(lawnTool);
        }

        // POST: LawnTools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LawnTool lawnTool = db.LawnTools.Find(id);
            db.LawnTools.Remove(lawnTool);
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
