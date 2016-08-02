namespace DataAccess
{
    using Entities;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class WebsiteDataContext : DbContext, IWebDataContext
    {
        public WebsiteDataContext()
            : base("WebsiteData")
        {
        }

        public virtual DbSet<Keyword> Keyword { get; set; }
        public virtual DbSet<Website> Website { get; set; }
        public virtual DbSet<IgnoreList> IgnoreList { get; set; }
        public virtual DbSet<RelatedKeywords> RelatedKeywords { get; set; }
        public virtual DbSet<SubDomain> SubDomain { get; set; }
        public virtual DbSet<WebPage> WebPage { get; set; }
        public virtual DbSet<WebPageKeywords> WebPageKeywords { get; set; } 
        public virtual DbSet<WebsiteKeywords> WebsiteKeywords { get; set; }
        public virtual DbSet<CalculatedTableUpdates> CalculatedTableUpdates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}