using CodingTest.EntityModels;
using CodingTest.EntityModels.Identity;
using CodingTest.IDomainServices.Services;
using CodingTest.ServiceResponse;
using CodingTest.Utility;
using CodingTest.ViewModels;
using Moq;
using System.Collections.Generic;
using System.Linq;
using CodingTest.IDomainServices.AutoMapper;


namespace CodingTest.Tests.Common.MockDomainServices
{
    public class UserNewsLetterServiceGenerator
    {
        private static List<NewsLetterEntityModel> newsLetterDataCollection = new List<NewsLetterEntityModel>();
        private static List<UserEntityModel> userDataCollection = new List<UserEntityModel>();
        private static List<UserNewsLetterEntityModel> userNewsLetterDataCollection = new List<UserNewsLetterEntityModel>();

        public static Mock<IUserNewsLetterService> GetMockService()
        {
            GetReadOnlyNewsLetterData();
            GetReadOnlyUserData();
            GetReadOnlyUserNewsLetterData();
            GetReadOnlyNewsLetterData();

            var mockService = new Mock<IUserNewsLetterService>();

            mockService.Setup(a => a.GetUserNewsLetters(It.IsAny<long>())).Returns<long>(userId =>
            {
                var response = new ResponseResults<NewsLetterViewModel> { IsSucceed = true, ViewModels = new System.Collections.Generic.List<NewsLetterViewModel>(), Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY };

                if (userId >0)
                {
                    var model = userNewsLetterDataCollection.FirstOrDefault(o=>o.UserId == userId);
                    if(model != null && model.NewsLetterIds.Length>0)
                    {
                        var longIds = AppMethods.StringToLongList(model.NewsLetterIds);
                        var models = newsLetterDataCollection.Where(o => longIds.Contains(o.Id));
                        response.ViewModels = models.ToViewModel<NewsLetterEntityModel, NewsLetterViewModel>().ToList();
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

        public static List<NewsLetterEntityModel> GetNewsLetterDataCollection()
        {
            return newsLetterDataCollection;
        }

        public static List<UserEntityModel> GetUserDataCollection()
        {
            return userDataCollection;
        }

        public static List<UserNewsLetterEntityModel> GetUserNewsLetterDataCollection()
        {
            return userNewsLetterDataCollection;
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
