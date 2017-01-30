namespace CodingTest.Repositories.Migrations
{
    using EntityModels;
    using FizzWare.NBuilder;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodingTest.Repositories.Core.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CodingTest.Repositories.Core.DataContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.NewsLetters.AddOrUpdate<NewsLetterEntityModel>(Builder<NewsLetterEntityModel>.CreateListOfSize(10).Build().ToArray());
            context.Database.ExecuteSqlCommand("INSERT [dbo].[KeyGroups] ([KeyGroup], [LocalizationKeys]) VALUES ( N'SignUpPage', N'EmailKey,PasswordKey,HeardAboutUsKey,ReasonforSignupKey,SubmitKey,IamInterestedInKey')");
            context.Database.ExecuteSqlCommand("INSERT [dbo].[KeyGroups] ([KeyGroup], [LocalizationKeys]) VALUES (N'LoginPage', N'EmailKey,PasswordKey')");
            context.Database.ExecuteSqlCommand("INSERT [dbo].[LocalizationKeys] ([LocalizationKey], [EnglishValue], [IrishValue], [IsActive]) VALUES ( N'EmailKey', N'Email', N'Email', 1)");
            context.Database.ExecuteSqlCommand("INSERT [dbo].[LocalizationKeys] ([LocalizationKey], [EnglishValue], [IrishValue], [IsActive]) VALUES (N'PasswordKey', N'Password', N'Password', 1)");
            context.Database.ExecuteSqlCommand("INSERT [dbo].[LocalizationKeys] ([LocalizationKey], [EnglishValue], [IrishValue], [IsActive]) VALUES (N'HeardAboutUsKey', N'Heard About Us', N'Heard About Us', 1)");
            context.Database.ExecuteSqlCommand("INSERT [dbo].[LocalizationKeys] ([LocalizationKey], [EnglishValue], [IrishValue], [IsActive]) VALUES (N'ReasonforSignupKey', N'Reason for signup', N'Reason for signup', 1)");
            context.Database.ExecuteSqlCommand("INSERT [dbo].[LocalizationKeys] ([LocalizationKey], [EnglishValue], [IrishValue], [IsActive]) VALUES (N'SubmitKey', N'Subscribe', N'Subscribe', 1)");
            context.Database.ExecuteSqlCommand("INSERT [dbo].[LocalizationKeys] ([LocalizationKey], [EnglishValue], [IrishValue], [IsActive]) VALUES (N'IamInterestedInKey', N'I am interested in', N'I am interested in', 1)");
        }
    }
}
