namespace Titanis.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubjectAndSemesterTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Semester",
                c => new
                    {
                        SemesterName = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false, identity: true),
                        SemesterCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SemesterName);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectCode = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectCode);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subject");
            DropTable("dbo.Semester");
        }
    }
}
