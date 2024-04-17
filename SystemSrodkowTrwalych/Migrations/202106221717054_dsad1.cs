namespace SystemSrodkowTrwalych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsad1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AmortizationRows",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AmortizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Amortizations", t => t.AmortizationId, cascadeDelete: true)
                .Index(t => t.AmortizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AmortizationRows", "AmortizationId", "dbo.Amortizations");
            DropIndex("dbo.AmortizationRows", new[] { "AmortizationId" });
            DropTable("dbo.AmortizationRows");
        }
    }
}
