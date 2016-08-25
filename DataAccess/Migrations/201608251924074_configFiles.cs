namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configFiles : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.WebpageKeywords", new[] { "WebPage_Id" });
            CreateIndex("dbo.WebpageKeywords", "Webpage_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.WebpageKeywords", new[] { "Webpage_Id" });
            CreateIndex("dbo.WebpageKeywords", "WebPage_Id");
        }
    }
}
