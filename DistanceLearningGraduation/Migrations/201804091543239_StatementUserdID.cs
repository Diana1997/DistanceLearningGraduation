namespace DistanceLearningGraduation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatementUserdID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Statements", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Statements", "UserID");
        }
    }
}
