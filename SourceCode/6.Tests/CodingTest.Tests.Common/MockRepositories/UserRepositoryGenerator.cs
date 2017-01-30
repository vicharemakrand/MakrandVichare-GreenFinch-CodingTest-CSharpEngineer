using CodingTest.EntityModels.Identity;
using CodingTest.IRepositories.Identity;
using CodingTest.Tests.Common;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CodingTest.Tests.DomainServices.MockRepositories
{
    public class UserRepositoryGenerator
    {
        private static List<UserEntityModel> dataCollection = new List<UserEntityModel>();

        public static Mock<IUserRepository> GetMockRepository()
        {
            GetReadOnlyData();
            var mockRepository = new Mock<IUserRepository>();

            mockRepository.Setup(a => a.Add(It.IsAny<UserEntityModel>())).Callback<UserEntityModel>(userEntity =>
            {
                dataCollection.Add(userEntity);
            });

            mockRepository.Setup(a => a.FindById(It.IsAny<long>())).Returns<long>(userId =>
            {
                return dataCollection.FirstOrDefault(o=>o.UserId == userId);
            });

            //mockRepository.Setup(a => a.FindByUserName(It.IsAny<string>())).Returns<string>(userName =>
            //{
            //    return dataCollection.FirstOrDefault(o => o.UserName == userName);
            //});

            return mockRepository;
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
