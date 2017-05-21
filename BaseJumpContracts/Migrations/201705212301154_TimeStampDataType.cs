namespace BaseJumpContracts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeStampDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventLog", "TimeStamp", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventLog", "TimeStamp", c => c.Int(nullable: false));
        }
    }
}
