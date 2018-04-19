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
    public class Expence_HistoryController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Expence_History
        public ActionResult Index()
        {
            var expence_Histories = db.Expence_Histories.Include(e => e.Bank_Account);
            return View(expence_Histories.ToList());
        }

        // GET: Expence_History/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expence_History expence_History = db.Expence_Histories.Find(id);
            if (expence_History == null)
            {
                return HttpNotFound();
            }
            return View(expence_History);
        }

        // GET: Expence_History/Create
        public ActionResult Create()
        {
            ViewBag.expence_history_bank_acc_id = new SelectList(db.Bank_Accounts, "bank_account_id", "bank_name");
            return View();
        }

        // POST: Expence_History/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "expence_history_id,expence_history_bank_acc_id,expence_history_expence_transac_id")] Expence_History expence_History)
        {
            if (ModelState.IsValid)
            {
                db.Expence_Histories.Add(expence_History);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.expence_history_bank_acc_id = new SelectList(db.Bank_Accounts, "bank_account_id", "bank_name", expence_History.expence_history_bank_acc_id);
            return View(expence_History);
        }

        // GET: Expence_History/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expence_History expence_History = db.Expence_Histories.Find(id);
            if (expence_History == null)
            {
                return HttpNotFound();
            }
            ViewBag.expence_history_bank_acc_id = new SelectList(db.Bank_Accounts, "bank_account_id", "bank_name", expence_History.expence_history_bank_acc_id);
            return View(expence_History);
        }

        // POST: Expence_History/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "expence_history_id,expence_history_bank_acc_id,expence_history_expence_transac_id")] Expence_History expence_History)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expence_History).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.expence_history_bank_acc_id = new SelectList(db.Bank_Accounts, "bank_account_id", "bank_name", expence_History.expence_history_bank_acc_id);
            return View(expence_History);
        }

        // GET: Expence_History/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expence_History expence_History = db.Expence_Histories.Find(id);
            if (expence_History == null)
            {
                return HttpNotFound();
            }
            return View(expence_History);
        }

        // POST: Expence_History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expence_History expence_History = db.Expence_Histories.Find(id);
            db.Expence_Histories.Remove(expence_History);
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
