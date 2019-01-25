namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNavbarForeignKeyToNavbarItems : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.NavbarDropDownItems", "NavbarItemId");
            AddForeignKey("dbo.NavbarDropDownItems", "NavbarItemId", "dbo.NavbarItems", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NavbarDropDownItems", "NavbarItemId", "dbo.NavbarItems");
            DropIndex("dbo.NavbarDropDownItems", new[] { "NavbarItemId" });
        }
    }
}
