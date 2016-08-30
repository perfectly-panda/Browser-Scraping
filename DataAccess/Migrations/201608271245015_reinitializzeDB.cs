namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reinitializzeDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IgnoreLists",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobLists",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        JobType = c.Int(nullable: false),
                        Url = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CompletedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobTrackings",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        JobType = c.Int(nullable: false),
                        LastRan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        Verified = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Webpages",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        WebsiteId = c.Guid(nullable: false),
                        SubDomainId = c.Guid(nullable: false),
                        Url = c.String(nullable: false),
                        FullHtml = c.String(),
                        BodyHtml = c.String(),
                        Title = c.String(),
                        LastAccessed = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubDomains", t => t.SubDomainId)
                .ForeignKey("dbo.Websites", t => t.WebsiteId)
                .Index(t => t.WebsiteId)
                .Index(t => t.SubDomainId);
            
            CreateTable(
                "dbo.SubDomains",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Domain = c.String(),
                        WebsiteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Websites", t => t.WebsiteId)
                .Index(t => t.WebsiteId);
            
            CreateTable(
                "dbo.Websites",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Domain = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WordCounts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        WebpageId = c.Guid(nullable: false),
                        Value = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Webpages", t => t.WebpageId, cascadeDelete: true)
                .Index(t => t.WebpageId);
            
            CreateTable(
                "dbo.RelatedKeywords",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        SecondaryKeyword_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Keywords", t => t.Id)
                .ForeignKey("dbo.Keywords", t => t.SecondaryKeyword_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.SecondaryKeyword_Id);
            
            CreateTable(
                "dbo.WebpageKeywords",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Keyword_Id = c.Guid(nullable: false),
                        Webpage_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Keywords", t => t.Keyword_Id, cascadeDelete: true)
                .ForeignKey("dbo.Webpages", t => t.Webpage_Id, cascadeDelete: true)
                .Index(t => t.Keyword_Id)
                .Index(t => t.Webpage_Id);
            
            CreateTable(
                "dbo.WebsiteKeywords",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Keyword_Id = c.Guid(nullable: false),
                        WebSite_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Keywords", t => t.Keyword_Id, cascadeDelete: true)
                .ForeignKey("dbo.Websites", t => t.WebSite_Id, cascadeDelete: true)
                .Index(t => t.Keyword_Id)
                .Index(t => t.WebSite_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WebsiteKeywords", "WebSite_Id", "dbo.Websites");
            DropForeignKey("dbo.WebsiteKeywords", "Keyword_Id", "dbo.Keywords");
            DropForeignKey("dbo.WebpageKeywords", "Webpage_Id", "dbo.Webpages");
            DropForeignKey("dbo.WebpageKeywords", "Keyword_Id", "dbo.Keywords");
            DropForeignKey("dbo.RelatedKeywords", "SecondaryKeyword_Id", "dbo.Keywords");
            DropForeignKey("dbo.RelatedKeywords", "Id", "dbo.Keywords");
            DropForeignKey("dbo.WordCounts", "WebpageId", "dbo.Webpages");
            DropForeignKey("dbo.Webpages", "WebsiteId", "dbo.Websites");
            DropForeignKey("dbo.Webpages", "SubDomainId", "dbo.SubDomains");
            DropForeignKey("dbo.SubDomains", "WebsiteId", "dbo.Websites");
            DropForeignKey("dbo.Links", "WebpageId", "dbo.Webpages");
            DropIndex("dbo.WebsiteKeywords", new[] { "WebSite_Id" });
            DropIndex("dbo.WebsiteKeywords", new[] { "Keyword_Id" });
            DropIndex("dbo.WebpageKeywords", new[] { "Webpage_Id" });
            DropIndex("dbo.WebpageKeywords", new[] { "Keyword_Id" });
            DropIndex("dbo.RelatedKeywords", new[] { "SecondaryKeyword_Id" });
            DropIndex("dbo.RelatedKeywords", new[] { "Id" });
            DropIndex("dbo.WordCounts", new[] { "WebpageId" });
            DropIndex("dbo.SubDomains", new[] { "WebsiteId" });
            DropIndex("dbo.Webpages", new[] { "SubDomainId" });
            DropIndex("dbo.Webpages", new[] { "WebsiteId" });
            DropIndex("dbo.Links", new[] { "WebpageId" });
            DropTable("dbo.WebsiteKeywords");
            DropTable("dbo.WebpageKeywords");
            DropTable("dbo.RelatedKeywords");
            DropTable("dbo.WordCounts");
            DropTable("dbo.Websites");
            DropTable("dbo.SubDomains");
            DropTable("dbo.Webpages");
            DropTable("dbo.Links");
            DropTable("dbo.Keywords");
            DropTable("dbo.JobTrackings");
            DropTable("dbo.JobLists");
            DropTable("dbo.IgnoreLists");
        }
    }
}
