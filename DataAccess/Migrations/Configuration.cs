namespace DataAccess.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.WebsiteDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.WebsiteDataContext context)
        {
            context.IgnoreList.AddOrUpdate(
                  new IgnoreList { Id= Guid.NewGuid(), Value = "the" }
                );
        }
    }
}
