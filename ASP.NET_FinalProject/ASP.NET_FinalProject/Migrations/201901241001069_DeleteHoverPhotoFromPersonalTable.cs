namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteHoverPhotoFromPersonalTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Personals", "HoverPhoto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personals", "HoverPhoto", c => c.String(nullable: false));
        }
    }
}
