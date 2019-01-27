namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBlogAndBlogCategoryTables : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BlogCategories", "BlogCategoryLink");
            DropColumn("dbo.Blogs", "BlogLink");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "BlogLink", c => c.String());
            AddColumn("dbo.BlogCategories", "BlogCategoryLink", c => c.String());
        }
    }
}
