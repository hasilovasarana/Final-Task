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
    public class KnowledgesController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Knowledges
        public ActionResult Index()
        {
            var knowledges = db.Knowledges.Include(k => k.Blog_Category);
            return View(knowledges.ToList());
        }

        // GET: Knowledges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knowledge knowledge = db.Knowledges.Find(id);
            if (knowledge == null)
            {
                return HttpNotFound();
            }
            return View(knowledge);
        }

        // GET: Knowledges/Create
        public ActionResult Create()
        {
            ViewBag.knowledge_blog_cat_id = new SelectList(db.Blog_Categories, "blog_cat_id", "blog_title");
            return View();
        }

        // POST: Knowledges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "knowledge_id,knowledge_blog_cat_id,knowledge_title,knowledge_detail,knowledge_date")] Knowledge knowledge)
        {
            if (ModelState.IsValid)
            {
                db.Knowledges.Add(knowledge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.knowledge_blog_cat_id = new SelectList(db.Blog_Categories, "blog_cat_id", "blog_title", knowledge.knowledge_blog_cat_id);
            return View(knowledge);
        }

        // GET: Knowledges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knowledge knowledge = db.Knowledges.Find(id);
            if (knowledge == null)
            {
                return HttpNotFound();
            }
            ViewBag.knowledge_blog_cat_id = new SelectList(db.Blog_Categories, "blog_cat_id", "blog_title", knowledge.knowledge_blog_cat_id);
            return View(knowledge);
        }

        // POST: Knowledges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "knowledge_id,knowledge_blog_cat_id,knowledge_title,knowledge_detail,knowledge_date")] Knowledge knowledge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knowledge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.knowledge_blog_cat_id = new SelectList(db.Blog_Categories, "blog_cat_id", "blog_title", knowledge.knowledge_blog_cat_id);
            return View(knowledge);
        }

        // GET: Knowledges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knowledge knowledge = db.Knowledges.Find(id);
            if (knowledge == null)
            {
                return HttpNotFound();
            }
            return View(knowledge);
        }

        // POST: Knowledges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Knowledge knowledge = db.Knowledges.Find(id);
            db.Knowledges.Remove(knowledge);
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
