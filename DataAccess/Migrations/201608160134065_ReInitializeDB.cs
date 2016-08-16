namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReInitializeDB : DbMigration
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
                "dbo.Keywords",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.SubDomains",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Domain = c.String(nullable: false),
                        Website_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Websites", t => t.Website_Id, cascadeDelete: true)
                .Index(t => t.Website_Id);
            
            CreateTable(
                "dbo.Websites",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Domain = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WebPages",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Url = c.String(nullable: false),
                        FullHtml = c.String(),
                        BodyHtml = c.String(),
                        Title = c.String(),
                        LastAccessed = c.DateTime(nullable: false),
                        SubDomain_Id = c.Guid(),
                        Website_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubDomains", t => t.SubDomain_Id)
                .ForeignKey("dbo.Websites", t => t.Website_Id, cascadeDelete: true)
                .Index(t => t.SubDomain_Id)
                .Index(t => t.Website_Id);
            
            CreateTable(
                "dbo.WebPageKeywords",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Keyword_Id = c.Guid(nullable: false),
                        WebPage_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Keywords", t => t.Keyword_Id, cascadeDelete: true)
                .ForeignKey("dbo.WebPages", t => t.WebPage_Id, cascadeDelete: true)
                .Index(t => t.Keyword_Id)
                .Index(t => t.WebPage_Id);
            
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
            DropForeignKey("dbo.WebPageKeywords", "WebPage_Id", "dbo.WebPages");
            DropForeignKey("dbo.WebPageKeywords", "Keyword_Id", "dbo.Keywords");
            DropForeignKey("dbo.WebPages", "Website_Id", "dbo.Websites");
            DropForeignKey("dbo.WebPages", "SubDomain_Id", "dbo.SubDomains");
            DropForeignKey("dbo.SubDomains", "Website_Id", "dbo.Websites");
            DropForeignKey("dbo.RelatedKeywords", "SecondaryKeyword_Id", "dbo.Keywords");
            DropForeignKey("dbo.RelatedKeywords", "Id", "dbo.Keywords");
            DropIndex("dbo.WebsiteKeywords", new[] { "WebSite_Id" });
            DropIndex("dbo.WebsiteKeywords", new[] { "Keyword_Id" });
            DropIndex("dbo.WebPageKeywords", new[] { "WebPage_Id" });
            DropIndex("dbo.WebPageKeywords", new[] { "Keyword_Id" });
            DropIndex("dbo.WebPages", new[] { "Website_Id" });
            DropIndex("dbo.WebPages", new[] { "SubDomain_Id" });
            DropIndex("dbo.SubDomains", new[] { "Website_Id" });
            DropIndex("dbo.RelatedKeywords", new[] { "SecondaryKeyword_Id" });
            DropIndex("dbo.RelatedKeywords", new[] { "Id" });
            DropTable("dbo.WebsiteKeywords");
            DropTable("dbo.WebPageKeywords");
            DropTable("dbo.WebPages");
            DropTable("dbo.Websites");
            DropTable("dbo.SubDomains");
            DropTable("dbo.RelatedKeywords");
            DropTable("dbo.Keywords");
            DropTable("dbo.IgnoreLists");
        }
    }
}
