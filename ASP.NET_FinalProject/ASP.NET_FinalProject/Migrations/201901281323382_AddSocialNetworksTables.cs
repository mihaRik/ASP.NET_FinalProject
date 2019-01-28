namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSocialNetworksTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialNetworkCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryIcon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialNetworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Link = c.String(),
                        SocialNetworkCategoryId = c.Int(nullable: false),
                        ReferenceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SocialNetworkCategories", t => t.SocialNetworkCategoryId, cascadeDelete: true)
                .Index(t => t.SocialNetworkCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialNetworks", "SocialNetworkCategoryId", "dbo.SocialNetworkCategories");
            DropIndex("dbo.SocialNetworks", new[] { "SocialNetworkCategoryId" });
            DropTable("dbo.SocialNetworks");
            DropTable("dbo.SocialNetworkCategories");
        }
    }
}
