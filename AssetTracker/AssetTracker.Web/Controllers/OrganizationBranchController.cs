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
    public class OrganizationBranchController : Controller
    {
        private AssetDBContext db = new AssetDBContext();

        // GET: /OrganizationBranch/
        public ActionResult Index()
        {
            var organizationbranches = db.OrganizationBranches.Include(o => o.Organization);
            return View(organizationbranches.ToList());
        }

        // GET: /OrganizationBranch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationBranch organizationbranch = db.OrganizationBranches.Find(id);
            if (organizationbranch == null)
            {
                return HttpNotFound();
            }
            return View(organizationbranch);
        }

        // GET: /OrganizationBranch/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            return View();
        }

        // POST: /OrganizationBranch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,ShortName,OrganizationId")] OrganizationBranch organizationbranch)
        {
            if (ModelState.IsValid)
            {
                db.OrganizationBranches.Add(organizationbranch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", organizationbranch.OrganizationId);
            return View(organizationbranch);
        }

        // GET: /OrganizationBranch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationBranch organizationbranch = db.OrganizationBranches.Find(id);
            if (organizationbranch == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", organizationbranch.OrganizationId);
            return View(organizationbranch);
        }

        // POST: /OrganizationBranch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,ShortName,OrganizationId")] OrganizationBranch organizationbranch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizationbranch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", organizationbranch.OrganizationId);
            return View(organizationbranch);
        }

        // GET: /OrganizationBranch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationBranch organizationbranch = db.OrganizationBranches.Find(id);
            if (organizationbranch == null)
            {
                return HttpNotFound();
            }
            return View(organizationbranch);
        }

        // POST: /OrganizationBranch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrganizationBranch organizationbranch = db.OrganizationBranches.Find(id);
            db.OrganizationBranches.Remove(organizationbranch);
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
