namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class websitechanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Websites", "Domain", c => c.String());
            DropColumn("dbo.Websites", "URL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Websites", "URL", c => c.String());
            DropColumn("dbo.Websites", "Domain");
        }
    }
}
