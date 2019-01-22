namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationInitialCreateverbose : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Body = c.String(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 150),
                        Title = c.String(maxLength: 50),
                        SuccessStory = c.String(),
                        Rating = c.Int(nullable: false),
                        Photo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        Resume = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModelCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 100),
                        AddDate = c.DateTime(nullable: false),
                        Author = c.String(nullable: false, maxLength: 100),
                        Body = c.String(nullable: false),
                        BlogCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfilePhoto = c.String(nullable: false, maxLength: 150),
                        HoverPhoto = c.String(maxLength: 150),
                        Name = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        AddDate = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        ModelCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NavbarDropDownItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NavbarItemId = c.Int(nullable: false),
                        NavItemName = c.String(nullable: false, maxLength: 100),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NavbarItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NavItemName = c.String(nullable: false, maxLength: 100),
                        Url = c.String(nullable: false),
                        IsDropDown = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Personals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 150),
                        Title = c.String(nullable: false, maxLength: 100),
                        PhotoUrl = c.String(nullable: false),
                        HoverPhoto = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelName = c.String(nullable: false, maxLength: 100),
                        MakeUp = c.String(nullable: false, maxLength: 100),
                        Photographer = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tags");
            DropTable("dbo.Projects");
            DropTable("dbo.Personals");
            DropTable("dbo.NavbarItems");
            DropTable("dbo.NavbarDropDownItems");
            DropTable("dbo.Models");
            DropTable("dbo.ModelCategories");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Clients");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogCategories");
        }
    }
}
