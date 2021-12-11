namespace Titanis.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        StreamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stream", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Stream",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreamName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "Id", "dbo.Stream");
            DropIndex("dbo.Course", new[] { "Id" });
            DropTable("dbo.Stream");
            DropTable("dbo.Course");
        }
    }
}
