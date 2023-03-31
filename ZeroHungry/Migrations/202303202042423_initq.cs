namespace ZeroHungry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initq : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollectRequests", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CollectRequests", "Status");
        }
    }
}
