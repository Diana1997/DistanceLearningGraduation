namespace DistanceLearningGraduation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LessonCOurseID : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(),
                        IsRight = c.Boolean(nullable: false),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerID)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        CourseID = c.Int(nullable: false),
                        LessonID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Lessons", t => t.LessonID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: false)
                .Index(t => t.CourseID)
                .Index(t => t.LessonID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TribuneID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Tribunes", t => t.TribuneID, cascadeDelete: false)
                .Index(t => t.TribuneID);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamID = c.Int(nullable: false, identity: true),
                        Day = c.DateTime(nullable: false),
                        Time = c.String(),
                        LessonID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: false)
                .ForeignKey("dbo.Lessons", t => t.LessonID, cascadeDelete: false)
                .Index(t => t.LessonID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        LessonID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LessonID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: false)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Lectures",
                c => new
                    {
                        LectureID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                        Links = c.String(),
                        LessonID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LectureID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: false)
                .ForeignKey("dbo.Lessons", t => t.LessonID, cascadeDelete: false)
                .Index(t => t.LessonID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Statements",
                c => new
                    {
                        StatementID = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Secondname = c.String(),
                        Lastname = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Email = c.String(),
                        Confirm = c.Boolean(nullable: false),
                        FacultyID = c.Int(nullable: false),
                        TribuneID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatementID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: false)
                .ForeignKey("dbo.Faculties", t => t.FacultyID, cascadeDelete: false)
                .ForeignKey("dbo.Tribunes", t => t.TribuneID, cascadeDelete: false)
                .Index(t => t.FacultyID)
                .Index(t => t.TribuneID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.FacultyID);
            
            CreateTable(
                "dbo.Tribunes",
                c => new
                    {
                        TribuneID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FacultyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TribuneID)
                .ForeignKey("dbo.Faculties", t => t.FacultyID, cascadeDelete: false)
                .Index(t => t.FacultyID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Statements", "TribuneID", "dbo.Tribunes");
            DropForeignKey("dbo.Tribunes", "FacultyID", "dbo.Faculties");
            DropForeignKey("dbo.Courses", "TribuneID", "dbo.Tribunes");
            DropForeignKey("dbo.Statements", "FacultyID", "dbo.Faculties");
            DropForeignKey("dbo.Statements", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Questions", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Questions", "LessonID", "dbo.Lessons");
            DropForeignKey("dbo.Lectures", "LessonID", "dbo.Lessons");
            DropForeignKey("dbo.Lectures", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Exams", "LessonID", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Exams", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Tribunes", new[] { "FacultyID" });
            DropIndex("dbo.Statements", new[] { "CourseID" });
            DropIndex("dbo.Statements", new[] { "TribuneID" });
            DropIndex("dbo.Statements", new[] { "FacultyID" });
            DropIndex("dbo.Lectures", new[] { "CourseID" });
            DropIndex("dbo.Lectures", new[] { "LessonID" });
            DropIndex("dbo.Lessons", new[] { "CourseID" });
            DropIndex("dbo.Exams", new[] { "CourseID" });
            DropIndex("dbo.Exams", new[] { "LessonID" });
            DropIndex("dbo.Courses", new[] { "TribuneID" });
            DropIndex("dbo.Questions", new[] { "LessonID" });
            DropIndex("dbo.Questions", new[] { "CourseID" });
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tribunes");
            DropTable("dbo.Faculties");
            DropTable("dbo.Statements");
            DropTable("dbo.Lectures");
            DropTable("dbo.Lessons");
            DropTable("dbo.Exams");
            DropTable("dbo.Courses");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
