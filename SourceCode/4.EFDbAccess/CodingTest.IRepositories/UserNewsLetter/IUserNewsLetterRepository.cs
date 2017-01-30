using CodingTest.EntityModels;
using CodingTest.IRepositories.Core;

namespace CodingTest.IRepositories.UserNewsLetter
{
    public interface IUserNewsLetterRepository : IIdentityBaseRepository<UserNewsLetterEntityModel>
    {
        UserNewsLetterEntityModel FindByUser(long userId);
    }
}
