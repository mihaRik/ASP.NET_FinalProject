namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhotoToBlogTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogPhoto", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "BlogPhoto");
        }
    }
}
