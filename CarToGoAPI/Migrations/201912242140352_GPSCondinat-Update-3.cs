namespace CarToGoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GPSCondinatUpdate3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GPSCordinat", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.GPSCordinat", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GPSCordinat", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.GPSCordinat", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
