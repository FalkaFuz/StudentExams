namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcontext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TestAccesses", "StudentGroup_Id", "dbo.StudentGroups");
            DropForeignKey("dbo.TestAccesses", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Tests", "ThematicArea_Id", "dbo.ThematicAreas");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.TestAccesses", "StudentGroup_Id", "dbo.StudentGroups", "Id");
            AddForeignKey("dbo.TestAccesses", "Test_Id", "dbo.Tests", "Id");
            AddForeignKey("dbo.Tests", "ThematicArea_Id", "dbo.ThematicAreas", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
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
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tests", "ThematicArea_Id", "dbo.ThematicAreas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TestAccesses", "Test_Id", "dbo.Tests", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TestAccesses", "StudentGroup_Id", "dbo.StudentGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
