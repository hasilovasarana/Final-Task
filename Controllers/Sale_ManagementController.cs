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
    public class Sale_ManagementController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Sale_Management
        public ActionResult Index()
        {
            var sale_Managements = db.Sale_Managements.Include(s => s.Customer).Include(s => s.Product_Category).Include(s => s.Product_Management).Include(s => s.Warehouse);
            return View(sale_Managements.ToList());
        }

        // GET: Sale_Management/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale_Management sale_Management = db.Sale_Managements.Find(id);
            if (sale_Management == null)
            {
                return HttpNotFound();
            }
            return View(sale_Management);
        }

        // GET: Sale_Management/Create
        public ActionResult Create()
        {
            ViewBag.sale_customer_id = new SelectList(db.Customers, "customer_id", "customer_full_name");
            ViewBag.sale_prod_cat_id = new SelectList(db.Product_Categories, "prod_category_id", "prod_category_name");
            ViewBag.sale_prod_manage_id = new SelectList(db.Product_Managements, "product_manage_id", "product_name");
            ViewBag.sale_warehouse_id = new SelectList(db.Warehouses, "warehouse_id", "warehouse_name");
            return View();
        }

        // POST: Sale_Management/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sale_id,sale_warehouse_id,sale_customer_id,sale_prod_cat_id,sale_prod_manage_id,quantity,sale_date")] Sale_Management sale_Management)
        {
            if (ModelState.IsValid)
            {
                db.Sale_Managements.Add(sale_Management);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sale_customer_id = new SelectList(db.Customers, "customer_id", "customer_full_name", sale_Management.sale_customer_id);
            ViewBag.sale_prod_cat_id = new SelectList(db.Product_Categories, "prod_category_id", "prod_category_name", sale_Management.sale_prod_cat_id);
            ViewBag.sale_prod_manage_id = new SelectList(db.Product_Managements, "product_manage_id", "product_name", sale_Management.sale_prod_manage_id);
            ViewBag.sale_warehouse_id = new SelectList(db.Warehouses, "warehouse_id", "warehouse_name", sale_Management.sale_warehouse_id);
            return View(sale_Management);
        }

        // GET: Sale_Management/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale_Management sale_Management = db.Sale_Managements.Find(id);
            if (sale_Management == null)
            {
                return HttpNotFound();
            }
            ViewBag.sale_customer_id = new SelectList(db.Customers, "customer_id", "customer_full_name", sale_Management.sale_customer_id);
            ViewBag.sale_prod_cat_id = new SelectList(db.Product_Categories, "prod_category_id", "prod_category_name", sale_Management.sale_prod_cat_id);
            ViewBag.sale_prod_manage_id = new SelectList(db.Product_Managements, "product_manage_id", "product_name", sale_Management.sale_prod_manage_id);
            ViewBag.sale_warehouse_id = new SelectList(db.Warehouses, "warehouse_id", "warehouse_name", sale_Management.sale_warehouse_id);
            return View(sale_Management);
        }

        // POST: Sale_Management/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sale_id,sale_warehouse_id,sale_customer_id,sale_prod_cat_id,sale_prod_manage_id,quantity,sale_date")] Sale_Management sale_Management)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale_Management).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sale_customer_id = new SelectList(db.Customers, "customer_id", "customer_full_name", sale_Management.sale_customer_id);
            ViewBag.sale_prod_cat_id = new SelectList(db.Product_Categories, "prod_category_id", "prod_category_name", sale_Management.sale_prod_cat_id);
            ViewBag.sale_prod_manage_id = new SelectList(db.Product_Managements, "product_manage_id", "product_name", sale_Management.sale_prod_manage_id);
            ViewBag.sale_warehouse_id = new SelectList(db.Warehouses, "warehouse_id", "warehouse_name", sale_Management.sale_warehouse_id);
            return View(sale_Management);
        }

        // GET: Sale_Management/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale_Management sale_Management = db.Sale_Managements.Find(id);
            if (sale_Management == null)
            {
                return HttpNotFound();
            }
            return View(sale_Management);
        }

        // POST: Sale_Management/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale_Management sale_Management = db.Sale_Managements.Find(id);
            db.Sale_Managements.Remove(sale_Management);
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
