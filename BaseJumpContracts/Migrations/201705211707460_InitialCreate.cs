namespace BaseJumpContracts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Subscription",
                c => new
                    {
                        SubscriptionID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Term = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubscriptionID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Service", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ServiceID);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EventLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TimeStamp = c.Int(nullable: false),
                        HtmlClass = c.String(),
                        EventType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscription", "ServiceID", "dbo.Service");
            DropForeignKey("dbo.Subscription", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Subscription", new[] { "ServiceID" });
            DropIndex("dbo.Subscription", new[] { "CustomerID" });
            DropTable("dbo.EventLog");
            DropTable("dbo.Service");
            DropTable("dbo.Subscription");
            DropTable("dbo.Customer");
        }
    }
}
