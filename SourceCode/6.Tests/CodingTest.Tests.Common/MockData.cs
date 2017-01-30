using CodingTest.EntityModels;
using CodingTest.EntityModels.Identity;
using System.Collections.Generic;

namespace CodingTest.Tests.Common
{
    public static class MockDB
    {
        public static MockDataCollection Collections = new MockDataCollection();

        public static void LoadAllDataFiles()
        {
            Helper.LoadMockData<UserNewsLetterEntityModel>();
            Helper.LoadMockData<NewsLetterEntityModel>();
            Helper.LoadMockData<UserEntityModel>();
        }
    }

    public class MockDataCollection
    {
        public List<UserNewsLetterEntityModel> UserNewsLetters = new List<UserNewsLetterEntityModel>();
        public List<NewsLetterEntityModel> NewsLetters = new List<NewsLetterEntityModel>();
        public List<UserEntityModel> Users = new List<UserEntityModel>();
    }
}
