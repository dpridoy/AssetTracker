using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssetTracker.Core.Models;
using AssetTracker.Core.Context;

namespace AssetTracker.Web.Controllers
{
    public class GeneralCategoryController : Controller
    {
        private AssetDBContext db = new AssetDBContext();

        // GET: /GeneralCategory/
        public ActionResult Index()
        {
            return View(db.GeneralCategories.ToList());
        }

        // GET: /GeneralCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralCategory generalcategory = db.GeneralCategories.Find(id);
            if (generalcategory == null)
            {
                return HttpNotFound();
            }
            return View(generalcategory);
        }

        // GET: /GeneralCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GeneralCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Code")] GeneralCategory generalcategory)
        {
            if (ModelState.IsValid)
            {
                db.GeneralCategories.Add(generalcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(generalcategory);
        }

        // GET: /GeneralCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralCategory generalcategory = db.GeneralCategories.Find(id);
            if (generalcategory == null)
            {
                return HttpNotFound();
            }
            return View(generalcategory);
        }

        // POST: /GeneralCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Code")] GeneralCategory generalcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(generalcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(generalcategory);
        }

        // GET: /GeneralCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralCategory generalcategory = db.GeneralCategories.Find(id);
            if (generalcategory == null)
            {
                return HttpNotFound();
            }
            return View(generalcategory);
        }

        // POST: /GeneralCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GeneralCategory generalcategory = db.GeneralCategories.Find(id);
            db.GeneralCategories.Remove(generalcategory);
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
