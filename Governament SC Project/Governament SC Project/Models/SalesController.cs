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
    public class SalesController : Controller
    {
        private GSFC_ProjectEntities db = new GSFC_ProjectEntities();

        // GET: Sales
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Customer).Include(s => s.Outlet).Include(s => s.Payment);
            return View(sales.ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.C_id = new SelectList(db.Customers, "C_ID", "First_Name");
            ViewBag.O_id = new SelectList(db.Outlets, "O_ID", "Size");
            ViewBag.P_ID = new SelectList(db.Payments, "P_ID", "Name");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sell_ID,C_id,O_id,P_ID,Quantity,Total_Price")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.C_id = new SelectList(db.Customers, "C_ID", "First_Name", sale.C_id);
            ViewBag.O_id = new SelectList(db.Outlets, "O_ID", "Size", sale.O_id);
            ViewBag.P_ID = new SelectList(db.Payments, "P_ID", "Name", sale.P_ID);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.C_id = new SelectList(db.Customers, "C_ID", "First_Name", sale.C_id);
            ViewBag.O_id = new SelectList(db.Outlets, "O_ID", "Size", sale.O_id);
            ViewBag.P_ID = new SelectList(db.Payments, "P_ID", "Name", sale.P_ID);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sell_ID,C_id,O_id,P_ID,Quantity,Total_Price")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.C_id = new SelectList(db.Customers, "C_ID", "First_Name", sale.C_id);
            ViewBag.O_id = new SelectList(db.Outlets, "O_ID", "Size", sale.O_id);
            ViewBag.P_ID = new SelectList(db.Payments, "P_ID", "Name", sale.P_ID);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sales.Find(id);
            db.Sales.Remove(sale);
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
