namespace Titanis.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicPerformance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RollNumber = c.String(maxLength: 128),
                        CurrentSemester = c.Int(nullable: false),
                        AttendancePercentage = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.RollNumber)
                .Index(t => t.RollNumber);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        RollNumber = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(),
                        Course = c.String(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        ParentPhoneNumber = c.Int(nullable: false),
                        GuardianName = c.String(),
                        GuardianPhoneNumber = c.Int(nullable: false),
                        AdmissionYear = c.Int(nullable: false),
                        GraduationYear = c.Int(nullable: false),
                        Batch = c.String(),
                    })
                .PrimaryKey(t => t.RollNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AcademicPerformance", "RollNumber", "dbo.Student");
            DropIndex("dbo.AcademicPerformance", new[] { "RollNumber" });
            DropTable("dbo.Student");
            DropTable("dbo.AcademicPerformance");
        }
    }
}
