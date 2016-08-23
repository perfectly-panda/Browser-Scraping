namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jobs : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobTrackings");
            DropTable("dbo.JobLists");
        }
    }
}
