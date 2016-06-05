namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuffhappened : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "RightAnswers");
            DropTable("dbo.QuestionTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Questions", "RightAnswers", c => c.Int(nullable: false));
        }
    }
}
