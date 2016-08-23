namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Keywords", "Verified", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Keywords", "Verified");
        }
    }
}
