namespace ElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_commentrelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "StudentID", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "CourseID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "StudentID");
            CreateIndex("dbo.Comments", "CourseID");
            AddForeignKey("dbo.Comments", "CourseID", "dbo.Courses", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "StudentID", "dbo.Students", "StudentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Comments", "CourseID", "dbo.Courses");
            DropIndex("dbo.Comments", new[] { "CourseID" });
            DropIndex("dbo.Comments", new[] { "StudentID" });
            DropColumn("dbo.Comments", "CourseID");
            DropColumn("dbo.Comments", "StudentID");
        }
    }
}
