using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using crm_system.Models;
using crm_system.Filters;

namespace crm_system.Controllers
{
    [CustomFilter]
    public class ReportsController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Reports
        public ActionResult Index()
        {
            var reports = db.Reports.Include(r => r.Manage_Supplier).Include(r => r.Supply_Management);
            return View(reports.ToList());
        }

        // GET: Reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // GET: Reports/Create
        public ActionResult Create()
        {
            ViewBag.report_id = new SelectList(db.Manage_Suppliers, "manage_supp_id", "supplier_name");
            ViewBag.report_id = new SelectList(db.Supply_Managements, "supply_manage_id", "item_name");
            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "report_id,report_supp_id,report_manage_supp_id")] Report report)
        {
            if (ModelState.IsValid)
            {
                db.Reports.Add(report);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.report_id = new SelectList(db.Manage_Suppliers, "manage_supp_id", "supplier_name", report.report_id);
            ViewBag.report_id = new SelectList(db.Supply_Managements, "supply_manage_id", "item_name", report.report_id);
            return View(report);
        }

        // GET: Reports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            ViewBag.report_id = new SelectList(db.Manage_Suppliers, "manage_supp_id", "supplier_name", report.report_id);
            ViewBag.report_id = new SelectList(db.Supply_Managements, "supply_manage_id", "item_name", report.report_id);
            return View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "report_id,report_supp_id,report_manage_supp_id")] Report report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.report_id = new SelectList(db.Manage_Suppliers, "manage_supp_id", "supplier_name", report.report_id);
            ViewBag.report_id = new SelectList(db.Supply_Managements, "supply_manage_id", "item_name", report.report_id);
            return View(report);
        }

        // GET: Reports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Report report = db.Reports.Find(id);
            db.Reports.Remove(report);
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
