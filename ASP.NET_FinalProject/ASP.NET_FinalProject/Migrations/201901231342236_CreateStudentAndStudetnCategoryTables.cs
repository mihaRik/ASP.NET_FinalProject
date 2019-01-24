namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStudentAndStudetnCategoryTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        StudentCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentCategories", t => t.StudentCategory_Id)
                .Index(t => t.StudentCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudentCategory_Id", "dbo.StudentCategories");
            DropIndex("dbo.Students", new[] { "StudentCategory_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.StudentCategories");
        }
    }
}
