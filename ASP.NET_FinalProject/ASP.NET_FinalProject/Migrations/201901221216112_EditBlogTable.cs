namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditBlogTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "AddDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Blogs", "Author", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Blogs", "BlogCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.ModelCategories", "CategoryName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.ModelCategories", "AddDate");
            DropColumn("dbo.ModelCategories", "Author");
            DropColumn("dbo.ModelCategories", "Body");
            DropColumn("dbo.ModelCategories", "BlogCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ModelCategories", "BlogCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.ModelCategories", "Body", c => c.String(nullable: false));
            AddColumn("dbo.ModelCategories", "Author", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.ModelCategories", "AddDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ModelCategories", "CategoryName", c => c.String(maxLength: 100));
            DropColumn("dbo.Blogs", "BlogCategoryId");
            DropColumn("dbo.Blogs", "Author");
            DropColumn("dbo.Blogs", "AddDate");
        }
    }
}
