namespace Titanis.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "Batch", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "Batch", c => c.String());
        }
    }
}
