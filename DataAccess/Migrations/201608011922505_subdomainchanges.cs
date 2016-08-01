namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subdomainchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubDomains", "Domain", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubDomains", "Domain");
        }
    }
}
