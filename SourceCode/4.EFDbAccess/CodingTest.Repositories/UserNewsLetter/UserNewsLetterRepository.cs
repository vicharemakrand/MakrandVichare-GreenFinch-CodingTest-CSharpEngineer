using CodingTest.Repositories.Core;
using System.Linq;
using System.Data.Entity;
using CodingTest.EntityModels;
using CodingTest.IRepositories.UserNewsLetter;

namespace CodingTest.Repositories.UserNewsLetter
{
    public class UserNewsLetterRepository : IdentityBaseRepository<UserNewsLetterEntityModel>, IUserNewsLetterRepository
    {

        public UserNewsLetterEntityModel FindByUser(long userId)
        {
            return DbSet.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
