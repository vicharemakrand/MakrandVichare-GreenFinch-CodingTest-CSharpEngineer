using CodingTest.EntityModels;
using CodingTest.EntityModels.Identity;
using CodingTest.IDomainServices.AutoMapper;
using CodingTest.IDomainServices.Services;
using CodingTest.ServiceResponse;
using CodingTest.Utility;
using CodingTest.Utility.ParamViewModels;
using CodingTest.ViewModels;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CodingTest.Tests.Common.MockDomainServices
{
    public class NewsLetterServiceGenerator
    {
        private static List<NewsLetterEntityModel> newsLetterDataCollection = new List<NewsLetterEntityModel>();
        private static List<UserEntityModel> userDataCollection = new List<UserEntityModel>();
        private static List<UserNewsLetterEntityModel> userNewsLetterDataCollection = new List<UserNewsLetterEntityModel>();

        public static Mock<INewsLetterService> GetMockService()
        {
            GetReadOnlyNewsLetterData();
            GetReadOnlyUserData();
            GetReadOnlyUserNewsLetterData();

            var mockService = new Mock<INewsLetterService>();

            mockService.Setup(a => a.GetTopNewsLetters(It.IsAny<long>())).Returns<long>(userId =>
            {
                var response = new ResponseResults<ViewModels.NewsLetterViewModel>() { IsSucceed = true, ViewModels = new List<ViewModels.NewsLetterViewModel>(), Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY };

                response.ViewModels = newsLetterDataCollection.Take(10).ToViewModel<NewsLetterEntityModel, NewsLetterViewModel>().ToList();

                if (userId > 0)
                {
                    var newsLetterIds = userNewsLetterDataCollection.FirstOrDefault(o => o.UserId == userId).NewsLetterIds;
                    var longIds = AppMethods.StringToLongList(newsLetterIds);

                    response.ViewModels.ForEach(o => o.IsSubscribed = longIds.Contains(o.Id));
                }

                if (response.ViewModels.Count <= 0)
                {
                    response.Message = AppMessages.NO_RECORD_FOUND;
                }
                return response;
            });

            mockService.Setup(a => a.GetNewsLetters(It.IsAny<SearchNewLetterViewModel>())).Returns<SearchNewLetterViewModel>(searchParam =>
            {
                var query = newsLetterDataCollection.AsQueryable();
                var response = new ResponseResults<NewsLetterViewModel>() { IsSucceed = true, ViewModels = new List<NewsLetterViewModel>(), Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY };

                if (!string.IsNullOrWhiteSpace(searchParam.Publisher))
                {
                    query = query.Where(o => o.Publisher.ToLower().Trim().Contains(searchParam.Publisher.ToLower().Trim()));
                }

                if (!string.IsNullOrWhiteSpace(searchParam.Author))
                {
                    query = query.Where(o => o.Author.Contains(searchParam.Author.Trim()));
                }

                var models = query.ToList();
                if (models != null && models.Count > 0)
                {
                    response.ViewModels = models.ToViewModel<NewsLetterEntityModel, NewsLetterViewModel>().ToList();
                    if (searchParam.UserId>0)
                    {
                        var newsLetterIds = userNewsLetterDataCollection.FirstOrDefault(o => o.UserId == searchParam.UserId).NewsLetterIds;
                        var longIds = AppMethods.StringToLongList(newsLetterIds);

                        response.ViewModels.ForEach(o => o.IsSubscribed = longIds.Contains(o.Id));
                    }
                }

                if (response.ViewModels.Count <= 0)
                {
                    response.Message = AppMessages.NO_RECORD_FOUND;
                }
                return response;
            });

            return mockService;
        }

        public static void ResetNewsLetterDataCollection(List<NewsLetterEntityModel> rows = null)
        {
            if (rows == null && MockDB.Collections.NewsLetters.Count == 0)
            {
                GetReadOnlyNewsLetterData();
            }
            
            rows = rows ?? MockDB.Collections.NewsLetters;
            EmptyNewsLetterDataCollection();
            newsLetterDataCollection.AddRange(Helper.DeepClone<List<NewsLetterEntityModel>>(rows));
        }

        public static void ResetUserDataCollection(List<UserEntityModel> rows = null)
        {
            if (rows == null && MockDB.Collections.Users.Count == 0)
            {
                GetReadOnlyUserData();
            }

            rows = rows ?? MockDB.Collections.Users;
            EmptyUserDataCollection();
            userDataCollection.AddRange(Helper.DeepClone<List<UserEntityModel>>(rows));
        }

        public static void ResetUserNewsLetterDataCollection(List<UserNewsLetterEntityModel> rows = null)
        {
            if (rows == null && MockDB.Collections.Users.Count == 0)
            {
                GetReadOnlyUserNewsLetterData();
            }

            rows = rows ?? MockDB.Collections.UserNewsLetters;
            EmptyUserNewsLetterDataCollection();
            userNewsLetterDataCollection.AddRange(Helper.DeepClone<List<UserNewsLetterEntityModel>>(rows));
        }

        public static void EmptyNewsLetterDataCollection()
        {
            newsLetterDataCollection = new List<NewsLetterEntityModel>();
        }

        public static void EmptyUserDataCollection()
        {
            userDataCollection = new List<UserEntityModel>();
        }

        public static void EmptyUserNewsLetterDataCollection()
        {
            userNewsLetterDataCollection = new List<UserNewsLetterEntityModel>();
        }

        public static List<NewsLetterEntityModel> GetDataCollection()
        {
            return newsLetterDataCollection;
        }

        public static void GetReadOnlyNewsLetterData()
        {
            if (MockDB.Collections.NewsLetters.Count == 0)
            {
                Helper.LoadMockData<NewsLetterEntityModel>();
            }

            ResetNewsLetterDataCollection();
        }

        public static void GetReadOnlyUserData()
        {
            if (MockDB.Collections.Users.Count == 0)
            {
                Helper.LoadMockData<UserEntityModel>();
            }

            ResetUserDataCollection();
        }

        public static void GetReadOnlyUserNewsLetterData()
        {
            if (MockDB.Collections.UserNewsLetters.Count == 0)
            {
                Helper.LoadMockData<UserNewsLetterEntityModel>();
            }

            ResetUserNewsLetterDataCollection();
        }
    }
}
