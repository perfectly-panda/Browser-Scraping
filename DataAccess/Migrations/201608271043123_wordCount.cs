namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wordCount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WordCounts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WebpageId = c.Guid(nullable: false),
                        Value = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Webpages", t => t.WebpageId, cascadeDelete: true)
                .Index(t => t.WebpageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WordCounts", "WebpageId", "dbo.Webpages");
            DropIndex("dbo.WordCounts", new[] { "WebpageId" });
            DropTable("dbo.WordCounts");
        }
    }
}
