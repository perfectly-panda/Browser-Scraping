namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subdomainEmpty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SubDomains", "Domain", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubDomains", "Domain", c => c.String(nullable: false));
        }
    }
}
