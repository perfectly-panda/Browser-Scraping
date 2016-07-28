namespace DataAccess
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class WebsiteDataContext : DbContext
    {
        public WebsiteDataContext()
            : base("WebsiteData")
        {
        }

        public virtual DbSet<Keywords> Keywords { get; set; }
        public virtual DbSet<Website> Website { get; set; }
        public virtual DbSet<IgnoreList> IgnoreList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}