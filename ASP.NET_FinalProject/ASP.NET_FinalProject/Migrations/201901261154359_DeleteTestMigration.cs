namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTestMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "StudentCategoryId", "dbo.StudentCategories");
            DropIndex("dbo.Students", new[] { "StudentCategoryId" });
            DropTable("dbo.StudentCategories");
            DropTable("dbo.Students");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        StudentCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Students", "StudentCategoryId");
            AddForeignKey("dbo.Students", "StudentCategoryId", "dbo.StudentCategories", "Id", cascadeDelete: true);
        }
    }
}
