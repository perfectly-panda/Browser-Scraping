namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class webpagedata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WebPages", "Url", c => c.String());
            AddColumn("dbo.WebPages", "FullHtml", c => c.String());
            AddColumn("dbo.WebPages", "BodyHtml", c => c.String());
            AddColumn("dbo.WebPages", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WebPages", "Title");
            DropColumn("dbo.WebPages", "BodyHtml");
            DropColumn("dbo.WebPages", "FullHtml");
            DropColumn("dbo.WebPages", "Url");
        }
    }
}
