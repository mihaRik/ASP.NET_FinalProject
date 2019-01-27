namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogCategoryLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogCategories", "BlogCategoryLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogCategories", "BlogCategoryLink");
        }
    }
}
