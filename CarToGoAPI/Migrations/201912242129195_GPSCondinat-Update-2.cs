namespace CarToGoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GPSCondinatUpdate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GPSCordinat", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.GPSCordinat", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GPSCordinat", "Longitude", c => c.Single(nullable: false));
            AlterColumn("dbo.GPSCordinat", "Latitude", c => c.Single(nullable: false));
        }
    }
}
