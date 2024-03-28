using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Governament_SC_Project.Models
{
    public class IncentivesController : Controller
    {
        private GSFC_ProjectEntities db = new GSFC_ProjectEntities();

        // GET: Incentives
        public ActionResult Index()
        {
            var incentives = db.Incentives.Include(i => i.Staff);
            return View(incentives.ToList());
        }

        // GET: Incentives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incentive incentive = db.Incentives.Find(id);
            if (incentive == null)
            {
                return HttpNotFound();
            }
            return View(incentive);
        }

        // GET: Incentives/Create
        public ActionResult Create()
        {
            ViewBag.Staff_ID = new SelectList(db.Staffs, "Staff_ID", "First_Name");
            return View();
        }

        // POST: Incentives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Incentives_ID,Staff_ID,Ammount")] Incentive incentive)
        {
            if (ModelState.IsValid)
            {
                db.Incentives.Add(incentive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Staff_ID = new SelectList(db.Staffs, "Staff_ID", "First_Name", incentive.Staff_ID);
            return View(incentive);
        }

        // GET: Incentives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incentive incentive = db.Incentives.Find(id);
            if (incentive == null)
            {
                return HttpNotFound();
            }
            ViewBag.Staff_ID = new SelectList(db.Staffs, "Staff_ID", "First_Name", incentive.Staff_ID);
            return View(incentive);
        }

        // POST: Incentives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Incentives_ID,Staff_ID,Ammount")] Incentive incentive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incentive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Staff_ID = new SelectList(db.Staffs, "Staff_ID", "First_Name", incentive.Staff_ID);
            return View(incentive);
        }

        // GET: Incentives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incentive incentive = db.Incentives.Find(id);
            if (incentive == null)
            {
                return HttpNotFound();
            }
            return View(incentive);
        }

        // POST: Incentives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Incentive incentive = db.Incentives.Find(id);
            db.Incentives.Remove(incentive);
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
