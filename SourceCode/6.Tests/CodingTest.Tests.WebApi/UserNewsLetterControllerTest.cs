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
    public class UserNewsLetterControllerTests
    {
        private static UserNewsLetterController controller;

        [ClassInitialize]
        public static void ClassInit(TestContext textContext)
        {
            controller = new UserNewsLetterController(UserNewsLetterServiceGenerator.GetMockService().Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            AutoMapperInit.BuildMap();

        }

        [TestInitialize]
        public void TestInit()
        {
            UserNewsLetterServiceGenerator.ResetUserNewsLetterDataCollection();
            UserManagerGenerator.ResetDataCollection();
        }

        [TestMethod]
        public async Task GetUserNewsLetters_ValidUserName_Returns_Records()
        {
            // Arrange
            var userId = UserManagerGenerator.GetDataCollection()[2].UserId;
            // Act
            var response = controller.GetUserNewsLetters(userId);
            dynamic responseContent = await response.Content.ReadAsAsync<ExpandoObject>();
            var selectedItems = responseContent.ViewModels;

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(selectedItems.Count>0);
        }

        [TestMethod]
        public async Task GetUserNewsLetters_ValidUserName_Returns_NoRecords()
        {
            // Arrange
            var userId = UserManagerGenerator.GetDataCollection()[0].UserId;
            UserNewsLetterServiceGenerator.EmptyUserNewsLetterDataCollection();
            // Act
            var response = controller.GetUserNewsLetters(userId);
            dynamic responseContent = await response.Content.ReadAsAsync<ExpandoObject>();
            var selectedItems = responseContent.ViewModels;

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(selectedItems.Count == 0);
        }

    }
}
