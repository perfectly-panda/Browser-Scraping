namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WebpageRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Webpages", "Website_Id", "dbo.Websites");
            DropIndex("dbo.Webpages", new[] { "SubDomain_Id" });
            AlterColumn("dbo.Webpages", "SubDomain_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.Webpages", "SubDomain_Id");
            AddForeignKey("dbo.Webpages", "Website_Id", "dbo.Websites", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Webpages", "Website_Id", "dbo.Websites");
            DropIndex("dbo.Webpages", new[] { "SubDomain_Id" });
            AlterColumn("dbo.Webpages", "SubDomain_Id", c => c.Guid());
            CreateIndex("dbo.Webpages", "SubDomain_Id");
            AddForeignKey("dbo.Webpages", "Website_Id", "dbo.Websites", "Id", cascadeDelete: true);
        }
    }
}
