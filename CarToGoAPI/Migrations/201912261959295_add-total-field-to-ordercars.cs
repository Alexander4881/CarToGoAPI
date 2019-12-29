namespace CarToGoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtotalfieldtoordercars : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderdCars", "Total", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderdCars", "Total");
        }
    }
}
