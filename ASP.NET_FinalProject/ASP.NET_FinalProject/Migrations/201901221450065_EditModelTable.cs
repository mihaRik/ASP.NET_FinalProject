namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditModelTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Models", "ProfilePhoto", c => c.String(nullable: false));
            AlterColumn("dbo.Models", "HoverPhoto", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Models", "HoverPhoto", c => c.String(maxLength: 150));
            AlterColumn("dbo.Models", "ProfilePhoto", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
