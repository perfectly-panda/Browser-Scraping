namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subdomainCascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubDomains", "Website_Id", "dbo.Websites");
            AddForeignKey("dbo.SubDomains", "Website_Id", "dbo.Websites", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubDomains", "Website_Id", "dbo.Websites");
            AddForeignKey("dbo.SubDomains", "Website_Id", "dbo.Websites", "Id", cascadeDelete: true);
        }
    }
}
