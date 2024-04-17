namespace SrodkiTrwale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FixedAssets", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FixedAssets", "ImageUrl");
        }
    }
}
