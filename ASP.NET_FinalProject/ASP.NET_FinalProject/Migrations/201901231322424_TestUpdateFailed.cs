namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestUpdateFailed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Models", "ModelCategory_Id", "dbo.ModelCategories");
            DropIndex("dbo.Models", new[] { "ModelCategory_Id" });
            AddColumn("dbo.Models", "ModelCategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Models", "ModelCategory_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "ModelCategory_Id", c => c.Int());
            DropColumn("dbo.Models", "ModelCategoryId");
            CreateIndex("dbo.Models", "ModelCategory_Id");
            AddForeignKey("dbo.Models", "ModelCategory_Id", "dbo.ModelCategories", "Id");
        }
    }
}
