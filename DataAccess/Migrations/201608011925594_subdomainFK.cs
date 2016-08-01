namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subdomainFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubDomains", "Website_Id", c => c.Guid());
            CreateIndex("dbo.SubDomains", "Website_Id");
            AddForeignKey("dbo.SubDomains", "Website_Id", "dbo.Websites", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubDomains", "Website_Id", "dbo.Websites");
            DropIndex("dbo.SubDomains", new[] { "Website_Id" });
            DropColumn("dbo.SubDomains", "Website_Id");
        }
    }
}
