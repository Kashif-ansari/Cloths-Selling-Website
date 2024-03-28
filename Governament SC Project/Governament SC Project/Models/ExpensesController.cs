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
    public class ExpensesController : Controller
    {
        private GSFC_ProjectEntities db = new GSFC_ProjectEntities();

        // GET: Expenses
        public ActionResult Index()
        {
            var expenses = db.Expenses.Include(e => e.Bill).Include(e => e.Inventory).Include(e => e.Incentive).Include(e => e.Stock);
            return View(expenses.ToList());
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            ViewBag.Bill_ID = new SelectList(db.Bills, "Bill_ID", "B_Name");
            ViewBag.I_ID = new SelectList(db.Inventories, "I_ID", "Inventory_Name");
            ViewBag.Incentives_ID = new SelectList(db.Incentives, "Incentives_ID", "Incentives_ID");
            ViewBag.Stock_ID = new SelectList(db.Stocks, "S_ID", "Stock_Name");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "E_ID,Incentives_ID,Stock_ID,Bill_ID,I_ID,Type,Name,Discription,Total")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bill_ID = new SelectList(db.Bills, "Bill_ID", "B_Name", expense.Bill_ID);
            ViewBag.I_ID = new SelectList(db.Inventories, "I_ID", "Inventory_Name", expense.I_ID);
            ViewBag.Incentives_ID = new SelectList(db.Incentives, "Incentives_ID", "Incentives_ID", expense.Incentives_ID);
            ViewBag.Stock_ID = new SelectList(db.Stocks, "S_ID", "Stock_Name", expense.Stock_ID);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bill_ID = new SelectList(db.Bills, "Bill_ID", "B_Name", expense.Bill_ID);
            ViewBag.I_ID = new SelectList(db.Inventories, "I_ID", "Inventory_Name", expense.I_ID);
            ViewBag.Incentives_ID = new SelectList(db.Incentives, "Incentives_ID", "Incentives_ID", expense.Incentives_ID);
            ViewBag.Stock_ID = new SelectList(db.Stocks, "S_ID", "Stock_Name", expense.Stock_ID);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "E_ID,Incentives_ID,Stock_ID,Bill_ID,I_ID,Type,Name,Discription,Total")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bill_ID = new SelectList(db.Bills, "Bill_ID", "B_Name", expense.Bill_ID);
            ViewBag.I_ID = new SelectList(db.Inventories, "I_ID", "Inventory_Name", expense.I_ID);
            ViewBag.Incentives_ID = new SelectList(db.Incentives, "Incentives_ID", "Incentives_ID", expense.Incentives_ID);
            ViewBag.Stock_ID = new SelectList(db.Stocks, "S_ID", "Stock_Name", expense.Stock_ID);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expense expense = db.Expenses.Find(id);
            db.Expenses.Remove(expense);
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
