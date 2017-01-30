using CodingTest.IDomainServices.AutoMapper;
using CodingTest.Tests.Common.MockDomainServices;
using CodingTest.WebApi2.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CodingTest.Tests.WebApi.Controller
{
    [TestClass]
    public class NewsLetterControllerTest
    {
        private static NewsLetterController controller;

        [ClassInitialize]
        public static void ClassInit(TestContext textContext)
        {
            controller = new NewsLetterController(NewsLetterServiceGenerator.GetMockService().Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            AutoMapperInit.BuildMap();

        }

        [TestInitialize]
        public void TestInit()
        {
            UserNewsLetterServiceGenerator.ResetUserNewsLetterDataCollection();
            NewsLetterServiceGenerator.ResetNewsLetterDataCollection();
            UserManagerGenerator.ResetDataCollection();
        }

        [TestMethod]
        public async Task GetNewsLetters_ValidSearchParam_Returns_Records()
        {
            // Arrange
            var userId = UserManagerGenerator.GetDataCollection()[0].UserId;
            var author = NewsLetterServiceGenerator.GetDataCollection()[0].Author;
            var searchParam = new Utility.ParamViewModels.SearchNewLetterViewModel { UserId = userId, Author = author };

            // Act
            var response = controller.GetNewsLetters(searchParam);
            dynamic responseContent = await response.Content.ReadAsAsync<ExpandoObject>();
            var selectedItems = responseContent.ViewModels;

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(selectedItems.Count > 0);
        }

        [TestMethod]
        public async Task GetNewsLetters_InValidSearchParam_Returns_NoRecords()
        {
           // Arrange
           var userId = UserManagerGenerator.GetDataCollection()[0].UserId;
            var author = "Author19999";

            var searchParam = new Utility.ParamViewModels.SearchNewLetterViewModel { UserId = userId, Author = author };
            // Act
            var response = controller.GetNewsLetters(searchParam);
            dynamic responseContent = await response.Content.ReadAsAsync<ExpandoObject>();
            var selectedItems = responseContent.ViewModels;

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(selectedItems.Count == 0);
        }

        [TestMethod]
        public async Task GetTopNewsLetters_ValidUserId_Returns_Records()
        {
            // Arrange
            var userId = UserManagerGenerator.GetDataCollection()[0].UserId;
            // Act
            var response = controller.GetTopNewsLetters(userId);
            dynamic responseContent = await response.Content.ReadAsAsync<ExpandoObject>();
            var selectedItems = responseContent.ViewModels;

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(selectedItems.Count > 0);
        }

        [TestMethod]
        public async Task GetTopNewsLetters_InValidUserId_Returns_NoRecords()
        {
            // Arrange
            var userId = 0;

            // Act
            var response = controller.GetTopNewsLetters(userId);
            dynamic responseContent = await response.Content.ReadAsAsync<ExpandoObject>();
            var selectedItems = responseContent.ViewModels;

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(selectedItems.Count > 0);
        }

        [TestMethod]
        public async Task GetNewsLetters_EmptyData_Returns_NoRecords()
        {
            //Arrange
           var userId = UserManagerGenerator.GetDataCollection()[0].UserId;
            var author = NewsLetterServiceGenerator.GetDataCollection()[0].Author;
            var searchParam = new Utility.ParamViewModels.SearchNewLetterViewModel { UserId = userId, Author = author };
            NewsLetterServiceGenerator.EmptyNewsLetterDataCollection();

            // Act
            var response = controller.GetNewsLetters(searchParam);
            dynamic responseContent = await response.Content.ReadAsAsync<ExpandoObject>();
            var selectedItems = responseContent.ViewModels;

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(selectedItems.Count == 0);
        }
    }
}
