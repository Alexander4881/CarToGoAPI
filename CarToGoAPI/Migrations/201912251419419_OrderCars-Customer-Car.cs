namespace CarToGoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderCarsCustomerCar : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderdCars", "CarID_ID", "dbo.Car");
            DropIndex("dbo.OrderdCars", new[] { "CarID_ID" });
            RenameColumn(table: "dbo.OrderdCars", name: "CarID_ID", newName: "CarID");
            AddColumn("dbo.OrderdCars", "CreateDT", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderdCars", "StarteDT", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderdCars", "EndDT", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderdCars", "ValidityDT", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderdCars", "PinkCode", c => c.String());
            AddColumn("dbo.OrderdCars", "QRCode", c => c.String());
            AddColumn("dbo.OrderdCars", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderdCars", "CarID", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderdCars", "CustomerID");
            CreateIndex("dbo.OrderdCars", "CarID");
            AddForeignKey("dbo.OrderdCars", "CustomerID", "dbo.Customer", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderdCars", "CarID", "dbo.Car", "ID", cascadeDelete: true);
            DropColumn("dbo.OrderdCars", "CreateDate");
            DropColumn("dbo.OrderdCars", "CustomeID");
            DropColumn("dbo.OrderdCars", "StarteTime");
            DropColumn("dbo.OrderdCars", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderdCars", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderdCars", "StarteTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderdCars", "CustomeID", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderdCars", "CreateDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.OrderdCars", "CarID", "dbo.Car");
            DropForeignKey("dbo.OrderdCars", "CustomerID", "dbo.Customer");
            DropIndex("dbo.OrderdCars", new[] { "CarID" });
            DropIndex("dbo.OrderdCars", new[] { "CustomerID" });
            AlterColumn("dbo.OrderdCars", "CarID", c => c.Int());
            DropColumn("dbo.OrderdCars", "CustomerID");
            DropColumn("dbo.OrderdCars", "QRCode");
            DropColumn("dbo.OrderdCars", "PinkCode");
            DropColumn("dbo.OrderdCars", "ValidityDT");
            DropColumn("dbo.OrderdCars", "EndDT");
            DropColumn("dbo.OrderdCars", "StarteDT");
            DropColumn("dbo.OrderdCars", "CreateDT");
            RenameColumn(table: "dbo.OrderdCars", name: "CarID", newName: "CarID_ID");
            CreateIndex("dbo.OrderdCars", "CarID_ID");
            AddForeignKey("dbo.OrderdCars", "CarID_ID", "dbo.Car", "ID");
        }
    }
}
