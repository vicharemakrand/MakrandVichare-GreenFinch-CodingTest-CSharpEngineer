using CodingTest.DomainServices;
using CodingTest.IDomainServices.AutoMapper;
using CodingTest.Tests.Common;
using CodingTest.Tests.Common.MockRepositories;
using CodingTest.Tests.DomainServices.MockRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reporting.BusinessTier.Tests
{
    [TestClass]
    public class NewsLetterServiceTests
    {
        private static NewsLetterService domainService;

        [ClassInitialize]
        public static void ClassInit(TestContext textContext)
        {
            domainService = new NewsLetterService();
            domainService.UnitOfWork = UnitOfWorkGenerator.MockUnitOfWork();
            AutoMapperInit.BuildMap();
        }

        [TestInitialize]
        public void Initialize()
        {
            NewsLetterRepositoryGenerator.ResetDataCollection();
        }

        [TestMethod]
        public void GetTopNewsLetters_Returns_Records()
        {
            //Arrange
            var userId = UserRepositoryGenerator.GetDataCollection()[0].UserId;
            //Act
            var response = domainService.GetTopNewsLetters(userId);

            //Assert
            Assert.IsTrue(response.IsSucceed);
            Assert.IsTrue(response.ViewModels.Count>0);
        }

        [TestMethod]
        public void GetTopNewsLetters_Returns_Returns_NoRecords()
        {
            //Arrange
            NewsLetterRepositoryGenerator.EmptyDataCollection();
            var userId = UserRepositoryGenerator.GetDataCollection()[0].UserId;

            //Act
            var response = domainService.GetTopNewsLetters(userId);

            //Assert
            Assert.IsTrue(response.ViewModels.Count == 0);
        }
    }
}
