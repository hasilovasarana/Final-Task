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
    public class Personal_LoanController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Personal_Loan
        public ActionResult Index()
        {
            return View(db.Personal_Loans.ToList());
        }

        // GET: Personal_Loan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Loan personal_Loan = db.Personal_Loans.Find(id);
            if (personal_Loan == null)
            {
                return HttpNotFound();
            }
            return View(personal_Loan);
        }

        // GET: Personal_Loan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personal_Loan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "personal_loan_id,person_name,person_phone,person_email,loan_amount,loan_detail")] Personal_Loan personal_Loan)
        {
            if (ModelState.IsValid)
            {
                db.Personal_Loans.Add(personal_Loan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personal_Loan);
        }

        // GET: Personal_Loan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Loan personal_Loan = db.Personal_Loans.Find(id);
            if (personal_Loan == null)
            {
                return HttpNotFound();
            }
            return View(personal_Loan);
        }

        // POST: Personal_Loan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "personal_loan_id,person_name,person_phone,person_email,loan_amount,loan_detail")] Personal_Loan personal_Loan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal_Loan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personal_Loan);
        }

        // GET: Personal_Loan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Loan personal_Loan = db.Personal_Loans.Find(id);
            if (personal_Loan == null)
            {
                return HttpNotFound();
            }
            return View(personal_Loan);
        }

        // POST: Personal_Loan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personal_Loan personal_Loan = db.Personal_Loans.Find(id);
            db.Personal_Loans.Remove(personal_Loan);
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
