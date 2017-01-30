using CodingTest.EntityModels;
using CodingTest.IRepositories.Core;
using CodingTest.Utility.ParamViewModels;
using System.Collections.Generic;

namespace CodingTest.IRepositories.NewsLetter
{
    public interface INewsLetterRepository : IIdentityBaseRepository<NewsLetterEntityModel>
    {
        List<NewsLetterEntityModel> GetNewsLetters(SearchNewLetterViewModel searchParam);
        List<NewsLetterEntityModel> GetNewsLettersByIds(List<long> Ids);
    }
}
