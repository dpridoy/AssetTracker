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
    public class AssetLocationController : Controller
    {
        private AssetDBContext db = new AssetDBContext();

        // GET: /AssetLocation/
        public ActionResult Index()
        {
            var assetlocations = db.AssetLocations.Include(a => a.OrganizationBranch);
            return View(assetlocations.ToList());
        }

        // GET: /AssetLocation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetlocation = db.AssetLocations.Find(id);
            if (assetlocation == null)
            {
                return HttpNotFound();
            }
            return View(assetlocation);
        }

        // GET: /AssetLocation/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationBranchId = new SelectList(db.OrganizationBranches, "Id", "Name");
            return View();
        }

        // POST: /AssetLocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,ShortName,OrganizationBranchId")] AssetLocation assetlocation)
        {
            if (ModelState.IsValid)
            {
                db.AssetLocations.Add(assetlocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationBranchId = new SelectList(db.OrganizationBranches, "Id", "Name", assetlocation.OrganizationBranchId);
            return View(assetlocation);
        }

        // GET: /AssetLocation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetlocation = db.AssetLocations.Find(id);
            if (assetlocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationBranchId = new SelectList(db.OrganizationBranches, "Id", "Name", assetlocation.OrganizationBranchId);
            return View(assetlocation);
        }

        // POST: /AssetLocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,ShortName,OrganizationBranchId")] AssetLocation assetlocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assetlocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationBranchId = new SelectList(db.OrganizationBranches, "Id", "Name", assetlocation.OrganizationBranchId);
            return View(assetlocation);
        }

        // GET: /AssetLocation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetlocation = db.AssetLocations.Find(id);
            if (assetlocation == null)
            {
                return HttpNotFound();
            }
            return View(assetlocation);
        }

        // POST: /AssetLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetLocation assetlocation = db.AssetLocations.Find(id);
            db.AssetLocations.Remove(assetlocation);
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
