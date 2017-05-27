namespace BaseJumpContracts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventLogger : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventLog", "Time", c => c.Long(nullable: false));
            AddColumn("dbo.EventLog", "TagName", c => c.String());
            AddColumn("dbo.EventLog", "Text", c => c.String());
            DropColumn("dbo.EventLog", "TimeStamp");
            DropColumn("dbo.EventLog", "EventType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventLog", "EventType", c => c.String());
            AddColumn("dbo.EventLog", "TimeStamp", c => c.Long(nullable: false));
            DropColumn("dbo.EventLog", "Text");
            DropColumn("dbo.EventLog", "TagName");
            DropColumn("dbo.EventLog", "Time");
        }
    }
}
