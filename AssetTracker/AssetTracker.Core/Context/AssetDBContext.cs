using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.Models;

namespace AssetTracker.Core.Context
{
    public class AssetDBContext:DbContext
    {
        public AssetDBContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationBranch> OrganizationBranches { get; set; } 
        public DbSet<AssetLocation> AssetLocations { get; set; }
        public DbSet<GeneralCategory> GeneralCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
