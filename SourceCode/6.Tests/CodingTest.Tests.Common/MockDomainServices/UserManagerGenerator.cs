using CodingTest.ViewModels.Identity;
using Microsoft.AspNet.Identity;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingTest.IDomainServices.AutoMapper;
using CodingTest.EntityModels.Identity;

namespace CodingTest.Tests.Common.MockDomainServices
{
    public class UserManagerGenerator
    {
        private static List<UserEntityModel> dataCollection = new List<UserEntityModel>();

        public static Mock<UserManager<IdentityUserViewModel, long>> GetMockService()
        {
            GetReadOnlyData();

            var mockUserManager = new Mock<UserManager<IdentityUserViewModel, long>>();

            mockUserManager.Setup(a => a.CreateAsync(It.IsAny<IdentityUserViewModel>())).Returns<IdentityUserViewModel>(viewModel =>
            {
                var userEntity = viewModel.ToEntityModel<UserEntityModel, IdentityUserViewModel>();
                dataCollection.Add(userEntity);
                return Task.FromResult(default(IdentityResult));
            });

            //mockUserManager.Setup(a => a.FindByName(It.IsAny<string>())).Returns<string>(userName =>
            //{
            //    return dataCollection.FirstOrDefault(o => o.UserName == userName).ToViewModel<UserEntityModel, IdentityUserViewModel>();
            //});

            mockUserManager.Setup(a => a.FindById(It.IsAny<long>())).Returns<long>(userId =>
            {
                return dataCollection.FirstOrDefault(o => o.UserId == userId).ToViewModel<UserEntityModel, IdentityUserViewModel>();
            });

            return mockUserManager;
        }

        public static void ResetDataCollection(List<UserEntityModel> rows = null)
        {
            if (rows == null && MockDB.Collections.Users.Count == 0)
            {
                GetReadOnlyData();
            }
            
            rows = rows ?? MockDB.Collections.Users;
            EmptyDataCollection();
            dataCollection.AddRange(Helper.DeepClone<List<UserEntityModel>>(rows));
        }

        public static void EmptyDataCollection()
        {
            dataCollection = new List<UserEntityModel>();
        }

        public static List<UserEntityModel> GetDataCollection()
        {
            return dataCollection;
        }

        public static void GetReadOnlyData()
        {
            if (MockDB.Collections.Users.Count == 0)
            {
                Helper.LoadMockData<UserEntityModel>();
            }

            ResetDataCollection();
        }
    }
}
