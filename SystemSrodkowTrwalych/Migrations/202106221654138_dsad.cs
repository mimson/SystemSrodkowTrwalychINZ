namespace SystemSrodkowTrwalych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Amortizations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FixedAssetsID = c.Int(nullable: false),
                        AmortizationValue = c.Int(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FixedAssets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoriesID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Name = c.String(),
                        DateOfCollections = c.DateTime(nullable: false),
                        Amortization_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoriesID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Amortizations", t => t.Amortization_ID)
                .Index(t => t.CategoriesID)
                .Index(t => t.UserID)
                .Index(t => t.Amortization_ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CatTypes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserRolesID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Mail = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserRoles", t => t.UserRolesID, cascadeDelete: true)
                .Index(t => t.UserRolesID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Roletype = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Raports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreactionDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        FixedAssets_ID = c.Int(),
                        Users_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FixedAssets", t => t.FixedAssets_ID)
                .ForeignKey("dbo.Users", t => t.Users_ID)
                .Index(t => t.FixedAssets_ID)
                .Index(t => t.Users_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Raports", "Users_ID", "dbo.Users");
            DropForeignKey("dbo.Raports", "FixedAssets_ID", "dbo.FixedAssets");
            DropForeignKey("dbo.FixedAssets", "Amortization_ID", "dbo.Amortizations");
            DropForeignKey("dbo.FixedAssets", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "UserRolesID", "dbo.UserRoles");
            DropForeignKey("dbo.FixedAssets", "CategoriesID", "dbo.Categories");
            DropIndex("dbo.Raports", new[] { "Users_ID" });
            DropIndex("dbo.Raports", new[] { "FixedAssets_ID" });
            DropIndex("dbo.Users", new[] { "UserRolesID" });
            DropIndex("dbo.FixedAssets", new[] { "Amortization_ID" });
            DropIndex("dbo.FixedAssets", new[] { "UserID" });
            DropIndex("dbo.FixedAssets", new[] { "CategoriesID" });
            DropTable("dbo.Raports");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
            DropTable("dbo.FixedAssets");
            DropTable("dbo.Amortizations");
        }
    }
}
