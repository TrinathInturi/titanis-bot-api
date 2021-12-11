namespace Titanis.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StaffTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staff", "Id", "dbo.Roles");
            DropIndex("dbo.Staff", new[] { "Id" });
            DropTable("dbo.Staff");
            DropTable("dbo.Roles");
        }
    }
}
