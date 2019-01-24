namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBlogTableForBlogArea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "SlidePhoto", c => c.String());
            AddColumn("dbo.Blogs", "IsSlide", c => c.Boolean());
            AddColumn("dbo.Blogs", "IsFeatured", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "IsFeatured");
            DropColumn("dbo.Blogs", "IsSlide");
            DropColumn("dbo.Blogs", "SlidePhoto");
        }
    }
}
