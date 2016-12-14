using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.DAL;
using AssetTracker.Core.Models;
using AssetTracker.Core.Models.ViewModel;

namespace AssetTracker.Core.BLL
{
    public class OrganizationManager
    {
        OrganizationRepository repository=new OrganizationRepository();

        public bool Add(Organization organization)
        {
            if (organization == null)
            {
                return false;
            }
            if (organization.Code.Length != 3)
            {
                return false;
            }
            return repository.Add(organization);
        }

        public Organization GetById(int id)
        {
            var organization = repository.GetById(id);
            return organization;
        }

        public bool Update(Organization organization)
        {
            bool isUpdate = repository.Update(organization);
            return isUpdate;
        }

        public List<Organization> Search(OrganizationSearchCriteria organizationSearch)
        {
            return repository.Search(organizationSearch);
        }
    }
}
