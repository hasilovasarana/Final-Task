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
    public class Expence_TransactionController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Expence_Transaction
        public ActionResult Index()
        {
            var expence_Transactions = db.Expence_Transactions.Include(e => e.Bank_Account);
            return View(expence_Transactions.ToList());
        }

        // GET: Expence_Transaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expence_Transaction expence_Transaction = db.Expence_Transactions.Find(id);
            if (expence_Transaction == null)
            {
                return HttpNotFound();
            }
            return View(expence_Transaction);
        }

        // GET: Expence_Transaction/Create
        public ActionResult Create()
        {
            ViewBag.transac_bank_acc_id = new SelectList(db.Bank_Accounts, "bank_account_id", "bank_name");
            return View();
        }

        // POST: Expence_Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "transaction_id,transac_bank_acc_id,transaction_amount,purpose_note,purpose_date")] Expence_Transaction expence_Transaction)
        {
            if (ModelState.IsValid)
            {
                db.Expence_Transactions.Add(expence_Transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.transac_bank_acc_id = new SelectList(db.Bank_Accounts, "bank_account_id", "bank_name", expence_Transaction.transac_bank_acc_id);
            return View(expence_Transaction);
        }

        // GET: Expence_Transaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expence_Transaction expence_Transaction = db.Expence_Transactions.Find(id);
            if (expence_Transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.transac_bank_acc_id = new SelectList(db.Bank_Accounts, "bank_account_id", "bank_name", expence_Transaction.transac_bank_acc_id);
            return View(expence_Transaction);
        }

        // POST: Expence_Transaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "transaction_id,transac_bank_acc_id,transaction_amount,purpose_note,purpose_date")] Expence_Transaction expence_Transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expence_Transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.transac_bank_acc_id = new SelectList(db.Bank_Accounts, "bank_account_id", "bank_name", expence_Transaction.transac_bank_acc_id);
            return View(expence_Transaction);
        }

        // GET: Expence_Transaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expence_Transaction expence_Transaction = db.Expence_Transactions.Find(id);
            if (expence_Transaction == null)
            {
                return HttpNotFound();
            }
            return View(expence_Transaction);
        }

        // POST: Expence_Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expence_Transaction expence_Transaction = db.Expence_Transactions.Find(id);
            db.Expence_Transactions.Remove(expence_Transaction);
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
