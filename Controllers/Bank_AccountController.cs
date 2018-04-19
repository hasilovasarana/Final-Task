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
    public class Bank_AccountController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Bank_Account
        public ActionResult Index()
        {
            return View(db.Bank_Accounts.ToList());
        }

        // GET: Bank_Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank_Account bank_Account = db.Bank_Accounts.Find(id);
            if (bank_Account == null)
            {
                return HttpNotFound();
            }
            return View(bank_Account);
        }

        // GET: Bank_Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bank_Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bank_account_id,bank_name,account_number,branch_name,swift_code")] Bank_Account bank_Account)
        {
            if (ModelState.IsValid)
            {
                db.Bank_Accounts.Add(bank_Account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bank_Account);
        }

        // GET: Bank_Account/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank_Account bank_Account = db.Bank_Accounts.Find(id);
            if (bank_Account == null)
            {
                return HttpNotFound();
            }
            return View(bank_Account);
        }

        // POST: Bank_Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bank_account_id,bank_name,account_number,branch_name,swift_code")] Bank_Account bank_Account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bank_Account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bank_Account);
        }

        // GET: Bank_Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank_Account bank_Account = db.Bank_Accounts.Find(id);
            if (bank_Account == null)
            {
                return HttpNotFound();
            }
            return View(bank_Account);
        }

        // POST: Bank_Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bank_Account bank_Account = db.Bank_Accounts.Find(id);
            db.Bank_Accounts.Remove(bank_Account);
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
