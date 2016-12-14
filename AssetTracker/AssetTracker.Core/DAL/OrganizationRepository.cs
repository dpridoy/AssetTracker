using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.Context;
using AssetTracker.Core.Models;
using AssetTracker.Core.Models.ViewModel;

namespace AssetTracker.Core.DAL
{
    public class OrganizationRepository
    {
        List<Organization> organizations=new List<Organization>();
        public bool Add(Organization organization)
        {
            AssetDBContext db = new AssetDBContext();
            db.Organizations.Add(organization);
            int rowAffected = db.SaveChanges();
            
            return rowAffected>0;
        }

        public bool Update(Organization organization)
        {
            AssetDBContext db=new AssetDBContext();
            db.Organizations.Attach(organization);
            db.Entry(organization).State=EntityState.Modified;
            int rowAffected = db.SaveChanges();
            return rowAffected>0;
        }

        public bool Remove(Organization organization)
        {
            return true;
        }

        public IList<Organization> GetAll()
        {
            AssetDBContext db=new AssetDBContext();
            var organizations = db.Organizations.Include(c=>c.OrganizationBranches).ToList();
            return organizations;
        }

        public Organization GetById(int id)
        {
            AssetDBContext db = new AssetDBContext();
            var organization = db.Organizations.Include(c=>c.OrganizationBranches).FirstOrDefault(c => c.Id == id);
            return organization;
        }

        public List<Organization> Search(OrganizationSearchCriteria searchCriteria)
        {
            AssetDBContext db=new AssetDBContext();
            var organization = db.Organizations.AsQueryable();
            if (!String.IsNullOrEmpty(searchCriteria.Name))
            {
                organization = organization.Where(c => c.Name.Contains(searchCriteria.Name));
            }
            if (!String.IsNullOrEmpty(searchCriteria.Code))
            {
                organization = organization.Where(c => c.Code.Contains(searchCriteria.Code));
            }
            if (!String.IsNullOrEmpty(searchCriteria.Location))
            {
                organization = organization.Where(c => c.Location.Contains(searchCriteria.Location));
            }
            return organization.ToList();
        } 
    }
}
