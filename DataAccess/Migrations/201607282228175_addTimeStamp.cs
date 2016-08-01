namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTimeStamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WebPages", "LastAccessed", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WebPages", "LastAccessed");
        }
    }
}
