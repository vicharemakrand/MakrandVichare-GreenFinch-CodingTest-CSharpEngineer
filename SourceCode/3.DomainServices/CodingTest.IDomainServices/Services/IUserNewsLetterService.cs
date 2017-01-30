using CodingTest.EntityModels;
using CodingTest.IDomainServices.Core;
using CodingTest.ServiceResponse;
using CodingTest.ViewModels;

namespace CodingTest.IDomainServices.Services
{
    public interface IUserNewsLetterService : IBaseService<UserNewsLetterEntityModel, UserNewsLetterViewModel>
    {
        ResponseResults<NewsLetterViewModel> GetUserNewsLetters(long userId);
    }
}
