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
    public class OutletsController : Controller
    {
        private GSFC_ProjectEntities db = new GSFC_ProjectEntities();

        // GET: Outlets
        public ActionResult Index()
        {
            var outlets = db.Outlets.Include(o => o.Item);
            return View(outlets.ToList());
        }

        // GET: Outlets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outlet outlet = db.Outlets.Find(id);
            if (outlet == null)
            {
                return HttpNotFound();
            }
            return View(outlet);
        }

        // GET: Outlets/Create
        public ActionResult Create()
        {
            ViewBag.Item_ID = new SelectList(db.Items, "Item_ID", "Item_Name");
            return View();
        }

        // POST: Outlets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "O_ID,Item_ID,Size,Price")] Outlet outlet)
        {
            if (ModelState.IsValid)
            {
                db.Outlets.Add(outlet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Item_ID = new SelectList(db.Items, "Item_ID", "Item_Name", outlet.Item_ID);
            return View(outlet);
        }

        // GET: Outlets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outlet outlet = db.Outlets.Find(id);
            if (outlet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Item_ID = new SelectList(db.Items, "Item_ID", "Item_Name", outlet.Item_ID);
            return View(outlet);
        }

        // POST: Outlets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "O_ID,Item_ID,Size,Price")] Outlet outlet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outlet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Item_ID = new SelectList(db.Items, "Item_ID", "Item_Name", outlet.Item_ID);
            return View(outlet);
        }

        // GET: Outlets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outlet outlet = db.Outlets.Find(id);
            if (outlet == null)
            {
                return HttpNotFound();
            }
            return View(outlet);
        }

        // POST: Outlets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outlet outlet = db.Outlets.Find(id);
            db.Outlets.Remove(outlet);
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
