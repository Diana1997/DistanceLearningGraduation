namespace DistanceLearningGraduation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questionanswer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            RenameColumn(table: "dbo.Answers", name: "QuestionID", newName: "Question_QuestionID");
            AlterColumn("dbo.Answers", "Question_QuestionID", c => c.Int());
            CreateIndex("dbo.Answers", "Question_QuestionID");
            AddForeignKey("dbo.Answers", "Question_QuestionID", "dbo.Questions", "QuestionID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "Question_QuestionID", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "Question_QuestionID" });
            AlterColumn("dbo.Answers", "Question_QuestionID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Answers", name: "Question_QuestionID", newName: "QuestionID");
            CreateIndex("dbo.Answers", "QuestionID");
            AddForeignKey("dbo.Answers", "QuestionID", "dbo.Questions", "QuestionID", cascadeDelete: true);
        }
    }
}
