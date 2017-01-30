using CodingTest.EntityModels;
using CodingTest.IRepositories.UserNewsLetter;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CodingTest.Tests.Common.MockRepositories
{
    public class UserNewsLetterRepositoryGenerator
    {
        private static List<UserNewsLetterEntityModel> dataCollection = new List<UserNewsLetterEntityModel>();

        public static Mock<IUserNewsLetterRepository> GetMockRepository()
        {
            GetReadOnlyData();
            var mockRepository = new Mock<IUserNewsLetterRepository>();

            mockRepository.Setup(a => a.Add(It.IsAny<UserNewsLetterEntityModel>())).Callback<UserNewsLetterEntityModel>(userDemandEntity =>
            {
                if(userDemandEntity.Id > 0 && string.IsNullOrWhiteSpace(userDemandEntity.NewsLetterIds))
                {
                    dataCollection.Add(userDemandEntity);
                }
            });

            mockRepository.Setup(a => a.GetMany(It.IsAny<Expression<Func<UserNewsLetterEntityModel,bool>>>())).Returns<Expression<Func<UserNewsLetterEntityModel, bool>>>(predicate =>
            {
                return dataCollection.AsQueryable().Where(predicate).ToList();
            });

            mockRepository.Setup(a => a.FindByUser(It.IsAny<long>())).Returns<long>(userId =>
            {
                return dataCollection.FirstOrDefault(o => o.UserId == userId);
            });

            return mockRepository;
        }

        public static void ResetDataCollection(List<UserNewsLetterEntityModel> rows = null)
        {
            if (rows == null && MockDB.Collections.UserNewsLetters.Count == 0)
            {
                GetReadOnlyData();
            }

            rows = rows ?? MockDB.Collections.UserNewsLetters;
            EmptyDataCollection();
            dataCollection.AddRange(Helper.DeepClone<List<UserNewsLetterEntityModel>>(rows));
        }

        public static void EmptyDataCollection()
        {
            dataCollection = new List<UserNewsLetterEntityModel>();
        }

        public static List<UserNewsLetterEntityModel> GetDataCollection()
        {
            return dataCollection;
        }

        public static void GetReadOnlyData()
        {
            if (MockDB.Collections.UserNewsLetters.Count == 0)
            {
                Helper.LoadMockData<UserNewsLetterEntityModel>();
            }
            ResetDataCollection();
        }
    }
}
