namespace CarToGoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderCarsUpdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderdCars", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderdCars", "Status");
        }
    }
}
