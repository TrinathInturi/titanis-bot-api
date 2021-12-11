namespace Titanis.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "StudentName", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "ParentPhoneNumber", c => c.Int());
            AlterColumn("dbo.Student", "GuardianPhoneNumber", c => c.Int());
            AlterColumn("dbo.Student", "AdmissionYear", c => c.Int());
            AlterColumn("dbo.Student", "GraduationYear", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "GraduationYear", c => c.Int(nullable: false));
            AlterColumn("dbo.Student", "AdmissionYear", c => c.Int(nullable: false));
            AlterColumn("dbo.Student", "GuardianPhoneNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Student", "ParentPhoneNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Student", "Email", c => c.String());
            AlterColumn("dbo.Student", "StudentName", c => c.String());
        }
    }
}
