namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestAddStudentTableForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        StudentCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentCategories", t => t.StudentCategoryId, cascadeDelete: true)
                .Index(t => t.StudentCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudentCategoryId", "dbo.StudentCategories");
            DropIndex("dbo.Students", new[] { "StudentCategoryId" });
            DropTable("dbo.Students");
            DropTable("dbo.StudentCategories");
        }
    }
}
