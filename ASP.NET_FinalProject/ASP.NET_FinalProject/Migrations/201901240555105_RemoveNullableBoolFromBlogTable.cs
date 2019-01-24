namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNullableBoolFromBlogTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "IsSlide", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Blogs", "IsFeatured", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "IsFeatured", c => c.Boolean());
            AlterColumn("dbo.Blogs", "IsSlide", c => c.Boolean());
        }
    }
}
