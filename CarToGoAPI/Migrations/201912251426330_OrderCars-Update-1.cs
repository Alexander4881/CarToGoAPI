namespace CarToGoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderCarsUpdate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderdCars", "StarteDT", c => c.DateTime());
            AlterColumn("dbo.OrderdCars", "EndDT", c => c.DateTime());
            AlterColumn("dbo.OrderdCars", "DrivenKM", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderdCars", "DrivenKM", c => c.Single(nullable: false));
            AlterColumn("dbo.OrderdCars", "EndDT", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrderdCars", "StarteDT", c => c.DateTime(nullable: false));
        }
    }
}
