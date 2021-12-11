namespace Titanis.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedExamTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Subject");
            CreateTable(
                "dbo.Exam",
                c => new
                    {
                        ExamCode = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false, identity: true),
                        ExamName = c.String(nullable: false),
                        SemesterCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamCode)
                .ForeignKey("dbo.Semester", t => t.SemesterCode, cascadeDelete: true)
                .Index(t => t.SemesterCode);
            
            AlterColumn("dbo.Subject", "SubjectCode", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Subject", "SubjectCode");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exam", "SemesterCode", "dbo.Semester");
            DropIndex("dbo.Exam", new[] { "SemesterCode" });
            DropPrimaryKey("dbo.Subject");
            AlterColumn("dbo.Subject", "SubjectCode", c => c.Int(nullable: false));
            DropTable("dbo.Exam");
            AddPrimaryKey("dbo.Subject", "SubjectCode");
        }
    }
}
