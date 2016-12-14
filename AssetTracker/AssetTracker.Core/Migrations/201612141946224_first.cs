namespace AssetTracker.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        OrganizationBranch_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrganizationBranches", t => t.OrganizationBranch_Id)
                .Index(t => t.OrganizationBranch_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        GeneralCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeneralCategories", t => t.GeneralCategoryID, cascadeDelete: true)
                .Index(t => t.GeneralCategoryID);
            
            CreateTable(
                "dbo.GeneralCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Designation = c.String(),
                        Contact = c.Int(nullable: false),
                        Email = c.String(),
                        OrganizationId = c.Int(nullable: false),
                        OrganizationBranchId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubCategories", t => t.SubCategory_Id)
                .Index(t => t.SubCategory_Id);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        GeneralCategoryId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCategoryId = c.Int(nullable: false),
                        ProductNumbers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategories", "SubCategory_Id", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "GeneralCategoryID", "dbo.GeneralCategories");
            DropForeignKey("dbo.AssetLocations", "OrganizationBranch_Id", "dbo.OrganizationBranches");
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropIndex("dbo.ProductCategories", new[] { "SubCategory_Id" });
            DropIndex("dbo.Categories", new[] { "GeneralCategoryID" });
            DropIndex("dbo.AssetLocations", new[] { "OrganizationBranch_Id" });
            DropTable("dbo.Vendors");
            DropTable("dbo.SubCategories");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.GeneralCategories");
            DropTable("dbo.Categories");
            DropTable("dbo.AssetLocations");
        }
    }
}
