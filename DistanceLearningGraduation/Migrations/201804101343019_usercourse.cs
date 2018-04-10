namespace DistanceLearningGraduation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usercourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCourses",
                c => new
                    {
                        UserCourseID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserCourseID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserCourses");
        }
    }
}
