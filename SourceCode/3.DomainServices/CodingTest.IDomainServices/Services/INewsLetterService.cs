using CodingTest.EntityModels;
using CodingTest.IDomainServices.Core;
using CodingTest.ServiceResponse;
using CodingTest.Utility.ParamViewModels;
using CodingTest.ViewModels;

namespace CodingTest.IDomainServices.Services
{
    public interface INewsLetterService : IBaseService<NewsLetterEntityModel, NewsLetterViewModel>
    {
        ResponseResults<NewsLetterViewModel> GetTopNewsLetters(long userId);
        ResponseResults<NewsLetterViewModel> GetNewsLetters(SearchNewLetterViewModel searchParam);
    }
}
