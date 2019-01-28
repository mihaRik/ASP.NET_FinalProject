namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteClientTableFromSocialTable3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SocialNetworks", "SingleBlog_Id", "dbo.Blogs");
            DropIndex("dbo.SocialNetworks", new[] { "SingleBlog_Id" });
            DropColumn("dbo.SocialNetworks", "Query");
            DropColumn("dbo.SocialNetworks", "Discriminator");
            DropColumn("dbo.SocialNetworks", "SingleBlog_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SocialNetworks", "SingleBlog_Id", c => c.Int());
            AddColumn("dbo.SocialNetworks", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.SocialNetworks", "Query", c => c.String());
            CreateIndex("dbo.SocialNetworks", "SingleBlog_Id");
            AddForeignKey("dbo.SocialNetworks", "SingleBlog_Id", "dbo.Blogs", "Id");
        }
    }
}
