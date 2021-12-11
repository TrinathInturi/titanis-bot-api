namespace Titanis.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Staff", "RoleId", "dbo.Roles");
            DropIndex("dbo.Staff", new[] { "RoleId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Staff");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateIndex("dbo.Staff", "RoleId");
            AddForeignKey("dbo.Staff", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
        }
    }
}
