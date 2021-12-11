namespace Titanis.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDepartmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentCode = c.String(),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Course", "DepartmentId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Course", "Id", "dbo.Departments", "Id");
            DropColumn("dbo.Course", "CourseName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Course", "CourseName", c => c.String());
            DropForeignKey("dbo.Course", "Id", "dbo.Departments");
            DropColumn("dbo.Course", "DepartmentId");
            DropTable("dbo.Departments");
        }
    }
}
