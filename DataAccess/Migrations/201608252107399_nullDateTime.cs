namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Webpages", "LastAccessed", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Webpages", "LastAccessed", c => c.DateTime(nullable: false));
        }
    }
}
