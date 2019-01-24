namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestoreDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "StudentCategory_Id", "dbo.StudentCategories");
            DropIndex("dbo.Students", new[] { "StudentCategory_Id" });
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
                        StudentCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Students", "StudentCategory_Id");
            AddForeignKey("dbo.Students", "StudentCategory_Id", "dbo.StudentCategories", "Id");
        }
    }
}
