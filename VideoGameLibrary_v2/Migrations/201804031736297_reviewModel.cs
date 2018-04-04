namespace VideoGameLibrary_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "DateCreated");
        }
    }
}
