namespace Titanis.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeChangeStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "CourseId", c => c.Int());
            CreateIndex("dbo.Student", "CourseId");
            AddForeignKey("dbo.Student", "CourseId", "dbo.Course", "Id");
            DropColumn("dbo.Student", "Course");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "Course", c => c.String());
            DropForeignKey("dbo.Student", "CourseId", "dbo.Course");
            DropIndex("dbo.Student", new[] { "CourseId" });
            DropColumn("dbo.Student", "CourseId");
        }
    }
}
