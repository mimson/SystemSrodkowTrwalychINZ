namespace SystemSrodkowTrwalych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsad1h : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AmortizationRows", "FixedAssetId", c => c.Int(nullable: false));
            CreateIndex("dbo.AmortizationRows", "FixedAssetId");
            AddForeignKey("dbo.AmortizationRows", "FixedAssetId", "dbo.FixedAssets", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AmortizationRows", "FixedAssetId", "dbo.FixedAssets");
            DropIndex("dbo.AmortizationRows", new[] { "FixedAssetId" });
            DropColumn("dbo.AmortizationRows", "FixedAssetId");
        }
    }
}
