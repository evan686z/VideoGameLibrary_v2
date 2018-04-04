namespace VideoGameLibrary_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviewreviewViewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Content", c => c.String(nullable: false));
            DropColumn("dbo.Reviews", "context");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "context", c => c.String());
            DropColumn("dbo.Reviews", "Content");
        }
    }
}
