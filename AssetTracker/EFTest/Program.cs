using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.BLL;
using AssetTracker.Core.Context;
using AssetTracker.Core.DAL;
using AssetTracker.Core.Models;
using AssetTracker.Core.Models.ViewModel;

namespace EFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //OrganizationRepository organizationRepository = new OrganizationRepository();
            //var organization = organizationRepository.GetById(2);

            //Console.WriteLine("Organization Name: " + organization.Name);
            //Console.WriteLine("Organization Code: " + organization.Code);
            //Console.WriteLine("Organization Location: " + organization.Location);

            //Organization organization=new Organization()
            //{
            //    Name = "TechnoBD",
            //    Code = "TEC",
            //    Location = "Dhaka"
            //};

            //OrganizationManager organizationManager=new OrganizationManager();
            //bool isSaved= organizationManager.Add(organization);
            //if (isSaved)
            //{
            //    Console.WriteLine("saved");
            //}
            //else
            //{
            //    Console.WriteLine("failed");
            //}
            //OrganizationBranch organizationBranch=new OrganizationBranch()
            //{
            //    Name = "Dhaka",
            //    OrganizationId = 1,
            //    ShortName = "DHK"
            //};

            //AssetDBContext db=new AssetDBContext();
            //db.OrganizationBranches.Add(organizationBranch);
            
            //int organizationId = 1;
            //AssetDBContext db=new AssetDBContext();
            //var organization = db.Organizations.FirstOrDefault(c => c.Id == organizationId);
            //organization.Name = "BASIS Institution of Technology Management";
            //int rowAffected = db.SaveChanges();
            int organizationId = 1;
            OrganizationManager organizationManager = new OrganizationManager();
            //var organization = organizationManager.GetById(organizationId);

            

            OrganizationSearchCriteria organizationSearch=new OrganizationSearchCriteria()
            {
                Name = "T",
                Location = "D",
            };

            var organizations = organizationManager.Search(organizationSearch);
            if (organizations != null && organizations.Any())
            {
                foreach (var organization in organizations)
                {
                    Console.WriteLine("Name: " + organization.Name);
                    Console.WriteLine("Code: " + organization.Code);
                    Console.WriteLine("Location: " + organization.Location);

                    //foreach (var VARIABLE in organization.OrganizationBranches)
                    //{
                    //    Console.WriteLine("Branch Name: " + VARIABLE.Name);
                    //    Console.WriteLine("Short Name: " + VARIABLE.ShortName);
                    //    Console.WriteLine(" ");
                    //}
                    
                }
            }

            Console.ReadKey();
        }
    }
}
