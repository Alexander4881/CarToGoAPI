namespace CarToGoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArduinoMessage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Message = c.String(),
                        Arduino_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RemoteDevice", t => t.Arduino_ID)
                .Index(t => t.Arduino_ID);
            
            CreateTable(
                "dbo.RemoteDevice",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CarBrand",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CarModel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        PricePerKM = c.Double(nullable: false),
                        PricePerMin = c.Double(nullable: false),
                        CarBandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarBrand", t => t.CarBandId, cascadeDelete: true)
                .Index(t => t.CarBandId);
            
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LicensePlate = c.String(),
                        AnimalsAllowed = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        TotalKM = c.Single(nullable: false),
                        CarModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarModel", t => t.CarModelId, cascadeDelete: true)
                .Index(t => t.CarModelId);
            
            CreateTable(
                "dbo.EletricEngine",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        EnergyLeft = c.Single(nullable: false),
                        KMsAvailable = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Car", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.GPSCordinat",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 6),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 6),
                        Received = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Car", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.OrderdCars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderNumber = c.String(),
                        Status = c.Int(nullable: false),
                        CreateDT = c.DateTime(nullable: false),
                        StarteDT = c.DateTime(),
                        EndDT = c.DateTime(),
                        ValidityDT = c.DateTime(nullable: false),
                        PinkCode = c.String(),
                        QRCode = c.String(),
                        DrivenKM = c.Single(),
                        Total = c.Single(),
                        CustomerID = c.Int(nullable: false),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Sex = c.Boolean(nullable: false),
                        FirstName = c.String(),
                        AftertName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        BithDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CreditCard",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        CreditCardNumber = c.String(),
                        CreditCardHolder = c.String(),
                        ExpiryDate = c.DateTime(nullable: false),
                        Ccv = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.DirversLicens",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        DriversLicensNumber = c.String(),
                        Country = c.String(),
                        ValidityDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarModel", "CarBandId", "dbo.CarBrand");
            DropForeignKey("dbo.OrderdCars", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.DirversLicens", "ID", "dbo.Customer");
            DropForeignKey("dbo.CreditCard", "ID", "dbo.Customer");
            DropForeignKey("dbo.OrderdCars", "CarID", "dbo.Car");
            DropForeignKey("dbo.GPSCordinat", "ID", "dbo.Car");
            DropForeignKey("dbo.EletricEngine", "ID", "dbo.Car");
            DropForeignKey("dbo.Car", "CarModelId", "dbo.CarModel");
            DropForeignKey("dbo.ArduinoMessage", "Arduino_ID", "dbo.RemoteDevice");
            DropIndex("dbo.DirversLicens", new[] { "ID" });
            DropIndex("dbo.CreditCard", new[] { "ID" });
            DropIndex("dbo.OrderdCars", new[] { "CarID" });
            DropIndex("dbo.OrderdCars", new[] { "CustomerID" });
            DropIndex("dbo.GPSCordinat", new[] { "ID" });
            DropIndex("dbo.EletricEngine", new[] { "ID" });
            DropIndex("dbo.Car", new[] { "CarModelId" });
            DropIndex("dbo.CarModel", new[] { "CarBandId" });
            DropIndex("dbo.ArduinoMessage", new[] { "Arduino_ID" });
            DropTable("dbo.DirversLicens");
            DropTable("dbo.CreditCard");
            DropTable("dbo.Customer");
            DropTable("dbo.OrderdCars");
            DropTable("dbo.GPSCordinat");
            DropTable("dbo.EletricEngine");
            DropTable("dbo.Car");
            DropTable("dbo.CarModel");
            DropTable("dbo.CarBrand");
            DropTable("dbo.RemoteDevice");
            DropTable("dbo.ArduinoMessage");
        }
    }
}
