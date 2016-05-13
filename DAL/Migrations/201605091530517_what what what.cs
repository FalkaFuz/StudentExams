namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatwhatwhat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Points = c.Int(nullable: false),
                        Explanation = c.String(),
                        QuestionType_Id = c.Int(nullable: false),
                        ThematicArea_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionTypes", t => t.QuestionType_Id, cascadeDelete: true)
                .ForeignKey("dbo.ThematicAreas", t => t.ThematicArea_Id, cascadeDelete: true)
                .Index(t => t.QuestionType_Id)
                .Index(t => t.ThematicArea_Id);
            
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ThematicAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        StudentGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentGroups", t => t.StudentGroup_Id)
                .Index(t => t.StudentGroup_Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestAccesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        StudentGroup_Id = c.Int(nullable: false),
                        Test_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentGroups", t => t.StudentGroup_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.Test_Id, cascadeDelete: true)
                .Index(t => t.StudentGroup_Id)
                .Index(t => t.Test_Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Time = c.Int(nullable: false),
                        QuestionCount = c.Int(nullable: false),
                        ThematicArea_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ThematicAreas", t => t.ThematicArea_Id, cascadeDelete: true)
                .Index(t => t.ThematicArea_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestAccesses", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Tests", "ThematicArea_Id", "dbo.ThematicAreas");
            DropForeignKey("dbo.TestAccesses", "StudentGroup_Id", "dbo.StudentGroups");
            DropForeignKey("dbo.Students", "StudentGroup_Id", "dbo.StudentGroups");
            DropForeignKey("dbo.Questions", "ThematicArea_Id", "dbo.ThematicAreas");
            DropForeignKey("dbo.Questions", "QuestionType_Id", "dbo.QuestionTypes");
            DropIndex("dbo.Tests", new[] { "ThematicArea_Id" });
            DropIndex("dbo.TestAccesses", new[] { "Test_Id" });
            DropIndex("dbo.TestAccesses", new[] { "StudentGroup_Id" });
            DropIndex("dbo.Students", new[] { "StudentGroup_Id" });
            DropIndex("dbo.Questions", new[] { "ThematicArea_Id" });
            DropIndex("dbo.Questions", new[] { "QuestionType_Id" });
            DropTable("dbo.Tests");
            DropTable("dbo.TestAccesses");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.StudentGroups");
            DropTable("dbo.ThematicAreas");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Questions");
        }
    }
}
