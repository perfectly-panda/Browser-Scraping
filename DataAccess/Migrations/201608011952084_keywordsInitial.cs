namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keywordsInitial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Keywords", "Value", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Keywords", "Value");
        }
    }
}
