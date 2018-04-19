using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crm_system.Filters;
using crm_system.Models;

namespace crm_system.Controllers
{
    [CustomFilter]
    public class BalancesController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Balances
        public ActionResult Index()
        {
            var balances = db.Balances.Include(b => b.Customer);
            return View(balances.ToList());
        }

        // GET: Balances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Balance balance = db.Balances.Find(id);
            if (balance == null)
            {
                return HttpNotFound();
            }
            return View(balance);
        }

        // GET: Balances/Create
        public ActionResult Create()
        {
            ViewBag.balance_customer_id = new SelectList(db.Customers, "customer_id", "customer_full_name");
            return View();
        }

        // POST: Balances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "balance_id,balance_customer_id,balance_amount,balance_note")] Balance balance)
        {
            if (ModelState.IsValid)
            {
                db.Balances.Add(balance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.balance_customer_id = new SelectList(db.Customers, "customer_id", "customer_full_name", balance.balance_customer_id);
            return View(balance);
        }

        // GET: Balances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Balance balance = db.Balances.Find(id);
            if (balance == null)
            {
                return HttpNotFound();
            }
            ViewBag.balance_customer_id = new SelectList(db.Customers, "customer_id", "customer_full_name", balance.balance_customer_id);
            return View(balance);
        }

        // POST: Balances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "balance_id,balance_customer_id,balance_amount,balance_note")] Balance balance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(balance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.balance_customer_id = new SelectList(db.Customers, "customer_id", "customer_full_name", balance.balance_customer_id);
            return View(balance);
        }

        // GET: Balances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Balance balance = db.Balances.Find(id);
            if (balance == null)
            {
                return HttpNotFound();
            }
            return View(balance);
        }

        // POST: Balances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Balance balance = db.Balances.Find(id);
            db.Balances.Remove(balance);
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
