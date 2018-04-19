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
    public class Subscribe_StatusController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Subscribe_Status
        public ActionResult Index()
        {
            return View(db.Subscribe_Status.ToList());
        }

        // GET: Subscribe_Status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribe_Status subscribe_Status = db.Subscribe_Status.Find(id);
            if (subscribe_Status == null)
            {
                return HttpNotFound();
            }
            return View(subscribe_Status);
        }

        // GET: Subscribe_Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subscribe_Status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sub_status_id,sub_status_check,from_date,to_date")] Subscribe_Status subscribe_Status)
        {
            if (ModelState.IsValid)
            {
                db.Subscribe_Status.Add(subscribe_Status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subscribe_Status);
        }

        // GET: Subscribe_Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribe_Status subscribe_Status = db.Subscribe_Status.Find(id);
            if (subscribe_Status == null)
            {
                return HttpNotFound();
            }
            return View(subscribe_Status);
        }

        // POST: Subscribe_Status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sub_status_id,sub_status_check,from_date,to_date")] Subscribe_Status subscribe_Status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscribe_Status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subscribe_Status);
        }

        // GET: Subscribe_Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribe_Status subscribe_Status = db.Subscribe_Status.Find(id);
            if (subscribe_Status == null)
            {
                return HttpNotFound();
            }
            return View(subscribe_Status);
        }

        // POST: Subscribe_Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscribe_Status subscribe_Status = db.Subscribe_Status.Find(id);
            db.Subscribe_Status.Remove(subscribe_Status);
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
