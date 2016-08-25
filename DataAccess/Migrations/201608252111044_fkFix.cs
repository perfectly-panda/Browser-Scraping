namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkFix : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Webpages", name: "SubDomain_Id", newName: "SubDomainId");
            RenameColumn(table: "dbo.SubDomains", name: "Website_Id", newName: "WebsiteId");
            RenameColumn(table: "dbo.Webpages", name: "Website_Id", newName: "WebsiteId");
            RenameIndex(table: "dbo.SubDomains", name: "IX_Website_Id", newName: "IX_WebsiteId");
            RenameIndex(table: "dbo.Webpages", name: "IX_Website_Id", newName: "IX_WebsiteId");
            RenameIndex(table: "dbo.Webpages", name: "IX_SubDomain_Id", newName: "IX_SubDomainId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Webpages", name: "IX_SubDomainId", newName: "IX_SubDomain_Id");
            RenameIndex(table: "dbo.Webpages", name: "IX_WebsiteId", newName: "IX_Website_Id");
            RenameIndex(table: "dbo.SubDomains", name: "IX_WebsiteId", newName: "IX_Website_Id");
            RenameColumn(table: "dbo.Webpages", name: "WebsiteId", newName: "Website_Id");
            RenameColumn(table: "dbo.SubDomains", name: "WebsiteId", newName: "Website_Id");
            RenameColumn(table: "dbo.Webpages", name: "SubDomainId", newName: "SubDomain_Id");
        }
    }
}
