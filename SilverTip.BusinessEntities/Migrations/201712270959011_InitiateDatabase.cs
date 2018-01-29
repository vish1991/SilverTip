namespace SilverTip.BusinessEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitiateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Funds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        BankId = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                        AccountNumber = c.Int(nullable: false),
                        Branch = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.SupplierFunds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        FundId = c.Int(nullable: false),
                        FundModeId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funds", t => t.FundId, cascadeDelete: true)
                .ForeignKey("dbo.FundModes", t => t.FundModeId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.FundId)
                .Index(t => t.FundModeId);
            
            CreateTable(
                "dbo.FundModes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNo = c.String(nullable: false, maxLength: 50),
                        FullName = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                        ContactNo = c.String(nullable: false, maxLength: 100),
                        Notes = c.String(),
                        NICNo = c.String(maxLength: 20),
                        RouteId = c.Int(nullable: false),
                        SupplierTypeId = c.Int(nullable: false),
                        LeafTypeId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LeafTypes", t => t.LeafTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .ForeignKey("dbo.SupplierTypes", t => t.SupplierTypeId, cascadeDelete: true)
                .Index(t => t.RouteId)
                .Index(t => t.SupplierTypeId)
                .Index(t => t.LeafTypeId);
            
            CreateTable(
                "dbo.LeafTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CollectionOfficerRoutes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CollectionOfficerId = c.Int(nullable: false),
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CollectionOfficers", t => t.CollectionOfficerId, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.CollectionOfficerId)
                .Index(t => t.RouteId);
            
            CreateTable(
                "dbo.CollectionOfficers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        ContactNo = c.String(),
                        Address = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        Route_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Routes", t => t.Route_Id)
                .Index(t => t.Route_Id);
            
            CreateTable(
                "dbo.LeafCollections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CollectedDate = c.DateTime(nullable: false),
                        FieldGrossWeight = c.Double(nullable: false),
                        FieldNetWeight = c.Double(nullable: false),
                        FactoryGrossWeight = c.Double(nullable: false),
                        FactoryNetWeight = c.Double(nullable: false),
                        CollectionOfficerRouteId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        CollectionOfficer_Id = c.Int(),
                        Route_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CollectionOfficerRoutes", t => t.CollectionOfficerRouteId, cascadeDelete: true)
                .ForeignKey("dbo.CollectionOfficers", t => t.CollectionOfficer_Id)
                .ForeignKey("dbo.Routes", t => t.Route_Id)
                .Index(t => t.CollectionOfficerRouteId)
                .Index(t => t.CollectionOfficer_Id)
                .Index(t => t.Route_Id);
            
            CreateTable(
                "dbo.LeafReconciliations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsBox = c.Boolean(nullable: false),
                        GrossWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Boxweight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BoilWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MassWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RouteDeduction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDeduction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LeafCollectionId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LeafCollections", t => t.LeafCollectionId, cascadeDelete: true)
                .Index(t => t.LeafCollectionId);
            
            CreateTable(
                "dbo.SupplierCollections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        CollectionOfficerId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        Route_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CollectionOfficers", t => t.CollectionOfficerId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.Route_Id)
                .Index(t => t.SupplierId)
                .Index(t => t.CollectionOfficerId)
                .Index(t => t.Route_Id);
            
            CreateTable(
                "dbo.SupplierPaymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankId = c.Int(),
                        AccountNumber = c.String(),
                        AccountName = c.String(),
                        Branch = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        PaymentTypeId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.BankId)
                .Index(t => t.PaymentTypeId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SupplierTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        ItemCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.ItemCategoryId, cascadeDelete: true)
                .Index(t => t.ItemCategoryId);
            
            CreateTable(
                "dbo.LogMessages",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ApplicationName = c.String(nullable: false, maxLength: 500),
                        Message = c.String(nullable: false),
                        User = c.String(nullable: false, maxLength: 256),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ItemCategoryId", "dbo.ItemCategories");
            DropForeignKey("dbo.Suppliers", "SupplierTypeId", "dbo.SupplierTypes");
            DropForeignKey("dbo.SupplierPaymentTypes", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.SupplierPaymentTypes", "PaymentTypeId", "dbo.PaymentTypes");
            DropForeignKey("dbo.SupplierPaymentTypes", "BankId", "dbo.Banks");
            DropForeignKey("dbo.SupplierFunds", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.SupplierCollections", "Route_Id", "dbo.Routes");
            DropForeignKey("dbo.LeafCollections", "Route_Id", "dbo.Routes");
            DropForeignKey("dbo.CollectionOfficers", "Route_Id", "dbo.Routes");
            DropForeignKey("dbo.CollectionOfficerRoutes", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.SupplierCollections", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.SupplierCollections", "CollectionOfficerId", "dbo.CollectionOfficers");
            DropForeignKey("dbo.LeafCollections", "CollectionOfficer_Id", "dbo.CollectionOfficers");
            DropForeignKey("dbo.LeafReconciliations", "LeafCollectionId", "dbo.LeafCollections");
            DropForeignKey("dbo.LeafCollections", "CollectionOfficerRouteId", "dbo.CollectionOfficerRoutes");
            DropForeignKey("dbo.CollectionOfficerRoutes", "CollectionOfficerId", "dbo.CollectionOfficers");
            DropForeignKey("dbo.Suppliers", "LeafTypeId", "dbo.LeafTypes");
            DropForeignKey("dbo.SupplierFunds", "FundModeId", "dbo.FundModes");
            DropForeignKey("dbo.SupplierFunds", "FundId", "dbo.Funds");
            DropForeignKey("dbo.Funds", "BankId", "dbo.Banks");
            DropIndex("dbo.Items", new[] { "ItemCategoryId" });
            DropIndex("dbo.SupplierPaymentTypes", new[] { "SupplierId" });
            DropIndex("dbo.SupplierPaymentTypes", new[] { "PaymentTypeId" });
            DropIndex("dbo.SupplierPaymentTypes", new[] { "BankId" });
            DropIndex("dbo.SupplierCollections", new[] { "Route_Id" });
            DropIndex("dbo.SupplierCollections", new[] { "CollectionOfficerId" });
            DropIndex("dbo.SupplierCollections", new[] { "SupplierId" });
            DropIndex("dbo.LeafReconciliations", new[] { "LeafCollectionId" });
            DropIndex("dbo.LeafCollections", new[] { "Route_Id" });
            DropIndex("dbo.LeafCollections", new[] { "CollectionOfficer_Id" });
            DropIndex("dbo.LeafCollections", new[] { "CollectionOfficerRouteId" });
            DropIndex("dbo.CollectionOfficers", new[] { "Route_Id" });
            DropIndex("dbo.CollectionOfficerRoutes", new[] { "RouteId" });
            DropIndex("dbo.CollectionOfficerRoutes", new[] { "CollectionOfficerId" });
            DropIndex("dbo.Suppliers", new[] { "LeafTypeId" });
            DropIndex("dbo.Suppliers", new[] { "SupplierTypeId" });
            DropIndex("dbo.Suppliers", new[] { "RouteId" });
            DropIndex("dbo.SupplierFunds", new[] { "FundModeId" });
            DropIndex("dbo.SupplierFunds", new[] { "FundId" });
            DropIndex("dbo.SupplierFunds", new[] { "SupplierId" });
            DropIndex("dbo.Funds", new[] { "BankId" });
            DropTable("dbo.LogMessages");
            DropTable("dbo.Items");
            DropTable("dbo.ItemCategories");
            DropTable("dbo.SupplierTypes");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.SupplierPaymentTypes");
            DropTable("dbo.SupplierCollections");
            DropTable("dbo.LeafReconciliations");
            DropTable("dbo.LeafCollections");
            DropTable("dbo.CollectionOfficers");
            DropTable("dbo.CollectionOfficerRoutes");
            DropTable("dbo.Routes");
            DropTable("dbo.LeafTypes");
            DropTable("dbo.Suppliers");
            DropTable("dbo.FundModes");
            DropTable("dbo.SupplierFunds");
            DropTable("dbo.Funds");
            DropTable("dbo.Banks");
        }
    }
}
