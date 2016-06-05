namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lala : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "IsCorrect", c => c.Boolean(nullable: false));
            DropColumn("dbo.Answers", "IsRight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "IsRight", c => c.Boolean(nullable: false));
            DropColumn("dbo.Answers", "IsCorrect");
        }
    }
}
