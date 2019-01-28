namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteClientTableFromSocialTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SocialNetworks", "Query", c => c.String());
            AddColumn("dbo.SocialNetworks", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.SocialNetworks", "SingleBlog_Id", c => c.Int());
            CreateIndex("dbo.SocialNetworks", "SingleBlog_Id");
            AddForeignKey("dbo.SocialNetworks", "SingleBlog_Id", "dbo.Blogs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialNetworks", "SingleBlog_Id", "dbo.Blogs");
            DropIndex("dbo.SocialNetworks", new[] { "SingleBlog_Id" });
            DropColumn("dbo.SocialNetworks", "SingleBlog_Id");
            DropColumn("dbo.SocialNetworks", "Discriminator");
            DropColumn("dbo.SocialNetworks", "Query");
        }
    }
}
