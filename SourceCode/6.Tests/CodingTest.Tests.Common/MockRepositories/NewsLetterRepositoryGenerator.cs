using CodingTest.EntityModels;
using CodingTest.IRepositories.NewsLetter;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CodingTest.Tests.Common.MockRepositories
{
    public class NewsLetterRepositoryGenerator
    {
        private static List<NewsLetterEntityModel> dataCollection = new List<NewsLetterEntityModel>();

        public static Mock<INewsLetterRepository> GetMockRepository()
        {
            GetReadOnlyData();
            var mockRepository = new Mock<INewsLetterRepository>();

            mockRepository.Setup(a => a.PageAll(It.IsAny<int>(), It.IsAny<int>())).Returns<int,int>((skip,take) =>
            {
                return dataCollection.Skip(skip).Take(take).ToList();
            });

            mockRepository.Setup(a => a.GetMany(It.IsAny<Expression<Func<NewsLetterEntityModel, bool>>>())).Returns<Expression<Func<NewsLetterEntityModel, bool>>>(predicate =>
            {
                return dataCollection.AsQueryable().Where(predicate).ToList();
            });

            mockRepository.Setup(a => a.GetNewsLettersByIds(It.IsAny<List<long>>())).Returns<List<long>>(newsLetterIds =>
            {
                return dataCollection.Where(o => newsLetterIds.Contains(o.Id)).ToList();
            });
            return mockRepository;
        }

        public static void ResetDataCollection(List<NewsLetterEntityModel> rows = null)
        {
            if (rows == null && MockDB.Collections.NewsLetters.Count == 0)
            {
                GetReadOnlyData();
            }

            rows = rows ?? MockDB.Collections.NewsLetters;
            EmptyDataCollection();
            dataCollection.AddRange(Helper.DeepClone<List<NewsLetterEntityModel>>(rows));
        }

        public static void EmptyDataCollection()
        {
            dataCollection = new List<NewsLetterEntityModel>();
        }

        public static List<NewsLetterEntityModel> GetDataCollection()
        {
            return dataCollection;
        }

        public static void GetReadOnlyData()
        {
            if (MockDB.Collections.NewsLetters.Count == 0)
            {
                Helper.LoadMockData<NewsLetterEntityModel>();
            }
            ResetDataCollection();
        }
    }
}
