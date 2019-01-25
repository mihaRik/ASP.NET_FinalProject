namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogLinkAndViewCountToBlogTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogLink", c => c.String());
            AddColumn("dbo.Blogs", "ViewCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "ViewCount");
            DropColumn("dbo.Blogs", "BlogLink");
        }
    }
}
