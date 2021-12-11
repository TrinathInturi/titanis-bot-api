namespace Titanis.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMarksTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        RollNumber = c.String(maxLength: 128),
                        ExamCode = c.String(maxLength: 128),
                        SubjectCode = c.String(maxLength: 128),
                        MaxMarks = c.Int(nullable: false),
                        ObtainedMarks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Exam", t => t.ExamCode)
                .ForeignKey("dbo.Student", t => t.RollNumber)
                .ForeignKey("dbo.Subject", t => t.SubjectCode)
                .Index(t => t.RollNumber)
                .Index(t => t.ExamCode)
                .Index(t => t.SubjectCode);
            
            AddColumn("dbo.Staff", "DepartmentId", c => c.Int());
            CreateIndex("dbo.Staff", "DepartmentId");
            AddForeignKey("dbo.Staff", "DepartmentId", "dbo.Departments", "DepartmentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staff", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Marks", "SubjectCode", "dbo.Subject");
            DropForeignKey("dbo.Marks", "RollNumber", "dbo.Student");
            DropForeignKey("dbo.Marks", "ExamCode", "dbo.Exam");
            DropIndex("dbo.Staff", new[] { "DepartmentId" });
            DropIndex("dbo.Marks", new[] { "SubjectCode" });
            DropIndex("dbo.Marks", new[] { "ExamCode" });
            DropIndex("dbo.Marks", new[] { "RollNumber" });
            DropColumn("dbo.Staff", "DepartmentId");
            DropTable("dbo.Marks");
        }
    }
}
