using CodingTest.DomainServices;
using CodingTest.IDomainServices.AutoMapper;
using CodingTest.Tests.Common;
using CodingTest.Tests.Common.MockRepositories;
using CodingTest.Tests.DomainServices.MockRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reporting.BusinessTier.Tests
{
    [TestClass]
    public class UserNewsLetterServiceTests
    {
        private static UserNewsLetterService domainService;

        [ClassInitialize]
        public static void ClassInit(TestContext textContext)
        {
            domainService = new UserNewsLetterService();
            domainService.UnitOfWork = UnitOfWorkGenerator.MockUnitOfWork();
            AutoMapperInit.BuildMap();
        }

        [TestInitialize]
        public void Initialize()
        {
            NewsLetterRepositoryGenerator.ResetDataCollection();
            UserRepositoryGenerator.ResetDataCollection();
        }

        [TestMethod]
        public void GetUserNewsLetters_ByValidUser_Returns_Records()
        {
            //Arrange
            var userId = UserRepositoryGenerator.GetDataCollection()[1].UserId;

            //Act
            var response = domainService.GetUserNewsLetters(userId);

            //Assert
            Assert.IsTrue(response.IsSucceed);
            Assert.IsTrue(response.ViewModels.Count>0);
        }

        [TestMethod]
        public void GetUserNewsLetters_ByInvalidUser_Returns_NoRecords()
        {
            //Arrange
            var userId = 0;
            //Act
            var response = domainService.GetUserNewsLetters(userId);

            //Assert
            Assert.IsTrue(response.ViewModels.Count == 0);
        }
    }
}
