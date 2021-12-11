namespace Titanis.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedFeilds : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
