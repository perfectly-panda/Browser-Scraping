namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class links : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        WebpageId = c.Guid(nullable: false),
                        URL = c.String(nullable: false),
                        LinkText = c.String(),
                        Internal = c.Boolean(),
                        Processed = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Webpages", t => t.WebpageId, cascadeDelete: true)
                .Index(t => t.WebpageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "WebpageId", "dbo.Webpages");
            DropIndex("dbo.Links", new[] { "WebpageId" });
            DropTable("dbo.Links");
        }
    }
}
