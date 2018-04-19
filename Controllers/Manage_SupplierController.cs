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
    public class Manage_SupplierController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Manage_Supplier
        public ActionResult Index()
        {
            var manage_Suppliers = db.Manage_Suppliers.Include(m => m.Report);
            return View(manage_Suppliers.ToList());
        }

        // GET: Manage_Supplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manage_Supplier manage_Supplier = db.Manage_Suppliers.Find(id);
            if (manage_Supplier == null)
            {
                return HttpNotFound();
            }
            return View(manage_Supplier);
        }

        // GET: Manage_Supplier/Create
        public ActionResult Create()
        {
            ViewBag.manage_supp_id = new SelectList(db.Reports, "report_id", "report_id");
            return View();
        }

        // POST: Manage_Supplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "manage_supp_id,supplier_name,supplier_mobile,supplier_email,supplier_address,supplier_product_item,supply_date")] Manage_Supplier manage_Supplier)
        {
            if (ModelState.IsValid)
            {
                db.Manage_Suppliers.Add(manage_Supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.manage_supp_id = new SelectList(db.Reports, "report_id", "report_id", manage_Supplier.manage_supp_id);
            return View(manage_Supplier);
        }

        // GET: Manage_Supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manage_Supplier manage_Supplier = db.Manage_Suppliers.Find(id);
            if (manage_Supplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.manage_supp_id = new SelectList(db.Reports, "report_id", "report_id", manage_Supplier.manage_supp_id);
            return View(manage_Supplier);
        }

        // POST: Manage_Supplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "manage_supp_id,supplier_name,supplier_mobile,supplier_email,supplier_address,supplier_product_item,supply_date")] Manage_Supplier manage_Supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manage_Supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.manage_supp_id = new SelectList(db.Reports, "report_id", "report_id", manage_Supplier.manage_supp_id);
            return View(manage_Supplier);
        }

        // GET: Manage_Supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manage_Supplier manage_Supplier = db.Manage_Suppliers.Find(id);
            if (manage_Supplier == null)
            {
                return HttpNotFound();
            }
            return View(manage_Supplier);
        }

        // POST: Manage_Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manage_Supplier manage_Supplier = db.Manage_Suppliers.Find(id);
            db.Manage_Suppliers.Remove(manage_Supplier);
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
