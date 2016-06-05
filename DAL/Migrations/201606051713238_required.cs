namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Questions", "ThematicArea_Id", "dbo.ThematicAreas");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TestAccesses", "StudentGroup_Id", "dbo.StudentGroups");
            DropForeignKey("dbo.TestAccesses", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Tests", "ThematicArea_Id", "dbo.ThematicAreas");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropIndex("dbo.Questions", new[] { "ThematicArea_Id" });
            AlterColumn("dbo.Answers", "Question_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "ThematicArea_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Answers", "Question_Id");
            CreateIndex("dbo.Questions", "ThematicArea_Id");
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "ThematicArea_Id", "dbo.ThematicAreas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TestAccesses", "StudentGroup_Id", "dbo.StudentGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TestAccesses", "Test_Id", "dbo.Tests", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tests", "ThematicArea_Id", "dbo.ThematicAreas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tests", "ThematicArea_Id", "dbo.ThematicAreas");
            DropForeignKey("dbo.TestAccesses", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.TestAccesses", "StudentGroup_Id", "dbo.StudentGroups");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Questions", "ThematicArea_Id", "dbo.ThematicAreas");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Questions", new[] { "ThematicArea_Id" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            AlterColumn("dbo.Questions", "ThematicArea_Id", c => c.Int());
            AlterColumn("dbo.Questions", "Text", c => c.String());
            AlterColumn("dbo.Answers", "Question_Id", c => c.Int());
            CreateIndex("dbo.Questions", "ThematicArea_Id");
            CreateIndex("dbo.Answers", "Question_Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tests", "ThematicArea_Id", "dbo.ThematicAreas", "Id");
            AddForeignKey("dbo.TestAccesses", "Test_Id", "dbo.Tests", "Id");
            AddForeignKey("dbo.TestAccesses", "StudentGroup_Id", "dbo.StudentGroups", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.Questions", "ThematicArea_Id", "dbo.ThematicAreas", "Id");
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id");
        }
    }
}
