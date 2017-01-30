namespace CodingTest.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialmakvTestDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ClaimId = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        ClaimType = c.String(maxLength: 4000),
                        ClaimValue = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ClaimId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 256),
                        PasswordHash = c.String(maxLength: 4000),
                        SecurityStamp = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserNewsLetters",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        NewsLetterIds = c.String(nullable: false, maxLength: 500),
                        Id = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.KeyGroups",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        KeyGroup = c.String(nullable: false, maxLength: 256),
                        LocalizationKeys = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LocalizationKeys",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LocalizationKey = c.String(nullable: false, maxLength: 256),
                        EnglishValue = c.String(nullable: false, maxLength: 4000),
                        IrishValue = c.String(nullable: false, maxLength: 4000),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsLetters",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 256),
                        Publisher = c.String(nullable: false, maxLength: 256),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Author = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);

            CreateIndex("dbo.KeyGroups", "KeyGroup", true, "INX_KeyGroups_KeyGroup");
            CreateIndex("dbo.LocalizationKeys", "LocalizationKey", true, "INX_LocalizationKeys_LocalizationKey");
            CreateIndex("dbo.Users", "Email", true, "INX_Users_Email");

        }

        public override void Down()
        {
            DropForeignKey("dbo.Claims", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserNewsLetters", "UserId", "dbo.Users");

            DropIndex("dbo.Users", "INX_Users_Email");
            DropIndex("dbo.KeyGroups", "INX_KeyGroups_KeyGroup");
            DropIndex("dbo.LocalizationKeys", "INX_LocalizationKeys_LocalizationKey");
            DropIndex("dbo.UserNewsLetters", new[] { "UserId" });
            DropIndex("dbo.Claims", new[] { "UserId" });

            DropTable("dbo.NewsLetters");
            DropTable("dbo.LocalizationKeys");
            DropTable("dbo.KeyGroups");
            DropTable("dbo.UserNewsLetters");
            DropTable("dbo.Users");
            DropTable("dbo.Claims");

        }
    }
}
