namespace Titanis.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseTabel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreamId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Stream", t => t.StreamId, cascadeDelete: true)
                .Index(t => t.StreamId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentCode = c.String(),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Stream",
                c => new
                    {
                        StreamId = c.Int(nullable: false, identity: true),
                        StreamName = c.String(),
                    })
                .PrimaryKey(t => t.StreamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "StreamId", "dbo.Stream");
            DropForeignKey("dbo.Course", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Course", new[] { "DepartmentId" });
            DropIndex("dbo.Course", new[] { "StreamId" });
            DropTable("dbo.Stream");
            DropTable("dbo.Departments");
            DropTable("dbo.Course");
        }
    }
}
