namespace ZeroHungry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectRequests",
                c => new
                    {
                        CollectRequestId = c.Int(nullable: false, identity: true),
                        FoodItem = c.String(),
                        RequestDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.CollectRequestId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Contact = c.String(),
                        Address = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Contact = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectRequests", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.CollectRequests", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.CollectRequests", new[] { "EmployeeId" });
            DropIndex("dbo.CollectRequests", new[] { "RestaurantId" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.Employees");
            DropTable("dbo.CollectRequests");
        }
    }
}
