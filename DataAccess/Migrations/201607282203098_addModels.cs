namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalculatedTableUpdates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TableName = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IgnoreLists",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RelatedKeywords",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Count = c.Int(nullable: false),
                        PrimaryKeyword_Id = c.Guid(),
                        SecondaryKeyword_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Keywords", t => t.PrimaryKeyword_Id)
                .ForeignKey("dbo.Keywords", t => t.SecondaryKeyword_Id)
                .Index(t => t.PrimaryKeyword_Id)
                .Index(t => t.SecondaryKeyword_Id);
            
            CreateTable(
                "dbo.SubDomains",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WebPages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SubDomain_Id = c.Guid(),
                        Website_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubDomains", t => t.SubDomain_Id)
                .ForeignKey("dbo.Websites", t => t.Website_Id)
                .Index(t => t.SubDomain_Id)
                .Index(t => t.Website_Id);
            
            CreateTable(
                "dbo.Websites",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WebPageKeywords",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Keyword_Id = c.Guid(),
                        WebPage_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Keywords", t => t.Keyword_Id)
                .ForeignKey("dbo.WebPages", t => t.WebPage_Id)
                .Index(t => t.Keyword_Id)
                .Index(t => t.WebPage_Id);
            
            CreateTable(
                "dbo.WebSiteKeywords",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Count = c.Int(nullable: false),
                        Keyword_Id = c.Guid(),
                        WebSite_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Keywords", t => t.Keyword_Id)
                .ForeignKey("dbo.Websites", t => t.WebSite_Id)
                .Index(t => t.Keyword_Id)
                .Index(t => t.WebSite_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WebSiteKeywords", "WebSite_Id", "dbo.Websites");
            DropForeignKey("dbo.WebSiteKeywords", "Keyword_Id", "dbo.Keywords");
            DropForeignKey("dbo.WebPageKeywords", "WebPage_Id", "dbo.WebPages");
            DropForeignKey("dbo.WebPageKeywords", "Keyword_Id", "dbo.Keywords");
            DropForeignKey("dbo.WebPages", "Website_Id", "dbo.Websites");
            DropForeignKey("dbo.WebPages", "SubDomain_Id", "dbo.SubDomains");
            DropForeignKey("dbo.RelatedKeywords", "SecondaryKeyword_Id", "dbo.Keywords");
            DropForeignKey("dbo.RelatedKeywords", "PrimaryKeyword_Id", "dbo.Keywords");
            DropIndex("dbo.WebSiteKeywords", new[] { "WebSite_Id" });
            DropIndex("dbo.WebSiteKeywords", new[] { "Keyword_Id" });
            DropIndex("dbo.WebPageKeywords", new[] { "WebPage_Id" });
            DropIndex("dbo.WebPageKeywords", new[] { "Keyword_Id" });
            DropIndex("dbo.WebPages", new[] { "Website_Id" });
            DropIndex("dbo.WebPages", new[] { "SubDomain_Id" });
            DropIndex("dbo.RelatedKeywords", new[] { "SecondaryKeyword_Id" });
            DropIndex("dbo.RelatedKeywords", new[] { "PrimaryKeyword_Id" });
            DropTable("dbo.WebSiteKeywords");
            DropTable("dbo.WebPageKeywords");
            DropTable("dbo.Websites");
            DropTable("dbo.WebPages");
            DropTable("dbo.SubDomains");
            DropTable("dbo.RelatedKeywords");
            DropTable("dbo.Keywords");
            DropTable("dbo.IgnoreLists");
            DropTable("dbo.CalculatedTableUpdates");
        }
    }
}
