namespace CarToGoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GPSCondinat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GPSCordinat", "Longitude", c => c.Single(nullable: false));
            AlterColumn("dbo.GPSCordinat", "Latitude", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GPSCordinat", "Latitude", c => c.Long(nullable: false));
            AlterColumn("dbo.GPSCordinat", "Longitude", c => c.Long(nullable: false));
        }
    }
}
