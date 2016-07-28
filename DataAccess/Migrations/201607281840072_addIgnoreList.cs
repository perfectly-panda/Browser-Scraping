namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIgnoreList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IgnoreLists",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IgnoreLists");
        }
    }
}
