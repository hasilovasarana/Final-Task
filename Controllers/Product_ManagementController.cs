using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crm_system.Models;
using crm_system.Filters;

namespace crm_system.Controllers
{
    [CustomFilter]
    public class Product_ManagementController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Product_Management
        public ActionResult Index()
        {
            var product_Managements = db.Product_Managements.Include(p => p.Product_Category);
            return View(product_Managements.ToList());
        }

        // GET: Product_Management/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Management product_Management = db.Product_Managements.Find(id);
            if (product_Management == null)
            {
                return HttpNotFound();
            }
            return View(product_Management);
        }

        // GET: Product_Management/Create
        public ActionResult Create()
        {
            ViewBag.prod_manag_prod_cat_id = new SelectList(db.Product_Categories, "prod_category_id", "prod_category_name");
            return View();
        }

        // POST: Product_Management/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_manage_id,prod_manag_prod_cat_id,product_name,product_unit,buying_price,selling_price")] Product_Management product_Management)
        {
            if (ModelState.IsValid)
            {
                db.Product_Managements.Add(product_Management);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.prod_manag_prod_cat_id = new SelectList(db.Product_Categories, "prod_category_id", "prod_category_name", product_Management.prod_manag_prod_cat_id);
            return View(product_Management);
        }

        // GET: Product_Management/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Management product_Management = db.Product_Managements.Find(id);
            if (product_Management == null)
            {
                return HttpNotFound();
            }
            ViewBag.prod_manag_prod_cat_id = new SelectList(db.Product_Categories, "prod_category_id", "prod_category_name", product_Management.prod_manag_prod_cat_id);
            return View(product_Management);
        }

        // POST: Product_Management/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_manage_id,prod_manag_prod_cat_id,product_name,product_unit,buying_price,selling_price")] Product_Management product_Management)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Management).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.prod_manag_prod_cat_id = new SelectList(db.Product_Categories, "prod_category_id", "prod_category_name", product_Management.prod_manag_prod_cat_id);
            return View(product_Management);
        }

        // GET: Product_Management/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Management product_Management = db.Product_Managements.Find(id);
            if (product_Management == null)
            {
                return HttpNotFound();
            }
            return View(product_Management);
        }

        // POST: Product_Management/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Management product_Management = db.Product_Managements.Find(id);
            db.Product_Managements.Remove(product_Management);
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
