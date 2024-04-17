namespace SrodkiTrwale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_prices : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FixedAssets", "AmortizationValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FixedAssets", "PurchasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FixedAssets", "CurrentPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FixedAssets", "CurrentPrice");
            DropColumn("dbo.FixedAssets", "PurchasePrice");
            DropColumn("dbo.FixedAssets", "AmortizationValue");
        }
    }
}
