namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Website_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Websites", t => t.Website_Id)
                .Index(t => t.Website_Id);
            
            CreateTable(
                "dbo.Websites",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Keywords", "Website_Id", "dbo.Websites");
            DropIndex("dbo.Keywords", new[] { "Website_Id" });
            DropTable("dbo.Websites");
            DropTable("dbo.Keywords");
        }
    }
}
