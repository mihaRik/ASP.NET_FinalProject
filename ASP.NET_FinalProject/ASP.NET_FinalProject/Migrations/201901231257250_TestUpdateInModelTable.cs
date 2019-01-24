namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestUpdateInModelTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Models", "ModelCategory_Id", c => c.Int());
            CreateIndex("dbo.Models", "ModelCategory_Id");
            AddForeignKey("dbo.Models", "ModelCategory_Id", "dbo.ModelCategories", "Id");
            DropColumn("dbo.Models", "ModelCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "ModelCategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Models", "ModelCategory_Id", "dbo.ModelCategories");
            DropIndex("dbo.Models", new[] { "ModelCategory_Id" });
            DropColumn("dbo.Models", "ModelCategory_Id");
        }
    }
}
