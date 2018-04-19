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
    public class Supply_ManagementController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Supply_Management
        public ActionResult Index()
        {
            var supply_Managements = db.Supply_Managements.Include(s => s.Manage_Supplier).Include(s => s.Subscribe_Status).Include(s => s.Report);
            return View(supply_Managements.ToList());
        }

        // GET: Supply_Management/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply_Management supply_Management = db.Supply_Managements.Find(id);
            if (supply_Management == null)
            {
                return HttpNotFound();
            }
            return View(supply_Management);
        }

        // GET: Supply_Management/Create
        public ActionResult Create()
        {
            ViewBag.supply_manage_supp_id = new SelectList(db.Manage_Suppliers, "manage_supp_id", "supplier_name");
            ViewBag.subscribe_status_id = new SelectList(db.Subscribe_Status, "sub_status_id", "sub_status_id");
            ViewBag.supply_manage_id = new SelectList(db.Reports, "report_id", "report_id");
            return View();
        }

        // POST: Supply_Management/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "supply_manage_id,supply_manage_supp_id,subscribe_status_id,rate,item_name,quantity,amount,total_amount")] Supply_Management supply_Management)
        {
            if (ModelState.IsValid)
            {
                db.Supply_Managements.Add(supply_Management);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.supply_manage_supp_id = new SelectList(db.Manage_Suppliers, "manage_supp_id", "supplier_name", supply_Management.supply_manage_supp_id);
            ViewBag.subscribe_status_id = new SelectList(db.Subscribe_Status, "sub_status_id", "sub_status_id", supply_Management.subscribe_status_id);
            ViewBag.supply_manage_id = new SelectList(db.Reports, "report_id", "report_id", supply_Management.supply_manage_id);
            return View(supply_Management);
        }

        // GET: Supply_Management/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply_Management supply_Management = db.Supply_Managements.Find(id);
            if (supply_Management == null)
            {
                return HttpNotFound();
            }
            ViewBag.supply_manage_supp_id = new SelectList(db.Manage_Suppliers, "manage_supp_id", "supplier_name", supply_Management.supply_manage_supp_id);
            ViewBag.subscribe_status_id = new SelectList(db.Subscribe_Status, "sub_status_id", "sub_status_id", supply_Management.subscribe_status_id);
            ViewBag.supply_manage_id = new SelectList(db.Reports, "report_id", "report_id", supply_Management.supply_manage_id);
            return View(supply_Management);
        }

        // POST: Supply_Management/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "supply_manage_id,supply_manage_supp_id,subscribe_status_id,rate,item_name,quantity,amount,total_amount")] Supply_Management supply_Management)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supply_Management).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.supply_manage_supp_id = new SelectList(db.Manage_Suppliers, "manage_supp_id", "supplier_name", supply_Management.supply_manage_supp_id);
            ViewBag.subscribe_status_id = new SelectList(db.Subscribe_Status, "sub_status_id", "sub_status_id", supply_Management.subscribe_status_id);
            ViewBag.supply_manage_id = new SelectList(db.Reports, "report_id", "report_id", supply_Management.supply_manage_id);
            return View(supply_Management);
        }

        // GET: Supply_Management/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply_Management supply_Management = db.Supply_Managements.Find(id);
            if (supply_Management == null)
            {
                return HttpNotFound();
            }
            return View(supply_Management);
        }

        // POST: Supply_Management/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supply_Management supply_Management = db.Supply_Managements.Find(id);
            db.Supply_Managements.Remove(supply_Management);
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
