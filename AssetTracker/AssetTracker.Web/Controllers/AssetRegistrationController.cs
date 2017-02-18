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
    public class AssetRegistrationController : Controller
    {
        private AssetDBContext db = new AssetDBContext();

        // GET: /AssetRegistration/
        public ActionResult Index()
        {
            var assetregistrations = db.AssetRegistrations.Include(a => a.Asset).Include(a => a.AssetLocation).Include(a => a.Employee).Include(a => a.Organization);
            return View(assetregistrations.ToList());
        }

        // GET: /AssetRegistration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetRegistration assetregistration = db.AssetRegistrations.Find(id);
            if (assetregistration == null)
            {
                return HttpNotFound();
            }
            return View(assetregistration);
        }

        // GET: /AssetRegistration/Create
        public ActionResult Create()
        {
            ViewBag.AssetId = new SelectList(db.Assets, "Id", "Name");
            ViewBag.AssetLocationId = new SelectList(db.AssetLocations, "Id", "Name");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name");
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            return View();
        }

        // POST: /AssetRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,AssetId,OrganizationId,SerialNo,RegistrationCode,Code,AssetLocationId,EmployeeId")] AssetRegistration assetregistration)
        {
            if (ModelState.IsValid)
            {
                db.AssetRegistrations.Add(assetregistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssetId = new SelectList(db.Assets, "Id", "Name", assetregistration.AssetId);
            ViewBag.AssetLocationId = new SelectList(db.AssetLocations, "Id", "Name", assetregistration.AssetLocationId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", assetregistration.EmployeeId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", assetregistration.OrganizationId);
            return View(assetregistration);
        }

        // GET: /AssetRegistration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetRegistration assetregistration = db.AssetRegistrations.Find(id);
            if (assetregistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetId = new SelectList(db.Assets, "Id", "Name", assetregistration.AssetId);
            ViewBag.AssetLocationId = new SelectList(db.AssetLocations, "Id", "Name", assetregistration.AssetLocationId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", assetregistration.EmployeeId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", assetregistration.OrganizationId);
            return View(assetregistration);
        }

        // POST: /AssetRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,AssetId,OrganizationId,SerialNo,RegistrationCode,Code,AssetLocationId,EmployeeId")] AssetRegistration assetregistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assetregistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssetId = new SelectList(db.Assets, "Id", "Name", assetregistration.AssetId);
            ViewBag.AssetLocationId = new SelectList(db.AssetLocations, "Id", "Name", assetregistration.AssetLocationId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", assetregistration.EmployeeId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", assetregistration.OrganizationId);
            return View(assetregistration);
        }

        // GET: /AssetRegistration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetRegistration assetregistration = db.AssetRegistrations.Find(id);
            if (assetregistration == null)
            {
                return HttpNotFound();
            }
            return View(assetregistration);
        }

        // POST: /AssetRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetRegistration assetregistration = db.AssetRegistrations.Find(id);
            db.AssetRegistrations.Remove(assetregistration);
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
