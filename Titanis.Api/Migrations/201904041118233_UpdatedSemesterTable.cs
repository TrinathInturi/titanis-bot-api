namespace Titanis.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSemesterTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Semester");
            AddColumn("dbo.Subject", "SemesterCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Semester", "SemesterName", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Semester", "SemesterCode");
            CreateIndex("dbo.Subject", "SemesterCode");
            AddForeignKey("dbo.Subject", "SemesterCode", "dbo.Semester", "SemesterCode", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subject", "SemesterCode", "dbo.Semester");
            DropIndex("dbo.Subject", new[] { "SemesterCode" });
            DropPrimaryKey("dbo.Semester");
            AlterColumn("dbo.Semester", "SemesterName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Subject", "SemesterCode");
            AddPrimaryKey("dbo.Semester", "SemesterName");
        }
    }
}
