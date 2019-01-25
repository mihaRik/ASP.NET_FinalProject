namespace ASP.NET_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectNameInProjectTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ProjectName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ProjectName");
        }
    }
}
