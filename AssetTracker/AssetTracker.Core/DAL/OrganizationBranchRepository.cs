using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.Context;
using AssetTracker.Core.Models;

namespace AssetTracker.Core.DAL
{
    public class OrganizationBranchRepository
    {
        List<OrganizationBranch> organizationBranches = new List<OrganizationBranch>();
        public bool Add(OrganizationBranch organizationBranch)
        {
            AssetDBContext db = new AssetDBContext();
            db.OrganizationBranches.Add(organizationBranch);
            int rowAffected = db.SaveChanges();

            return rowAffected > 0;
        }

        public bool Update(OrganizationBranch organization)
        {
            AssetDBContext db = new AssetDBContext();
            db.OrganizationBranches.Attach(organization);
            db.Entry(organization).State = EntityState.Modified;
            int rowAffected = db.SaveChanges();
            return rowAffected > 0;
        }

        public IList<OrganizationBranch> GetAll()
        {
            AssetDBContext db = new AssetDBContext();
            var organizations = db.OrganizationBranches.ToList();
            return organizations;
        }

        public OrganizationBranch GetById(int id)
        {
            AssetDBContext db = new AssetDBContext();
            var organization = db.OrganizationBranches.FirstOrDefault(c => c.Id == id);
            return organization;
        }
    }
}
