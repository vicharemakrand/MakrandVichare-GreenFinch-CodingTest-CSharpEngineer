using CodingTest.Repositories.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Threading;
using CodingTest.EntityModels.Identity;
using CodingTest.IRepositories.Identity;

namespace CodingTest.Repositories.Identity
{
    public class UserRepository : BaseRepository<UserEntityModel>, IUserRepository
    {
        public UserRepository()
        { }

        //public UserRepository(DataContext dataContext)
        //    : base(dataContext)
        //{
        //}

        public UserEntityModel FindByEmail(string email)
        {
            return DbSet.FirstOrDefault(x => x.Email == email);
        }

        public Task<UserEntityModel> FindByEmailAsync(string email)
        {
            return DbSet.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<UserEntityModel> FindByEmailAsync(CancellationToken cancellationToken, string email)
        {
            return DbSet.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }

        //public UserEntityModel FindByUserName(string username)
        //{
        //    return DbSet.FirstOrDefault(x => x.UserName == username);
        //}

        //public Task<UserEntityModel> FindByUserNameAsync(string username)
        //{
        //    return DbSet.FirstOrDefaultAsync(x => x.UserName == username);
        //}

        //public Task<UserEntityModel> FindByUserNameAsync(CancellationToken cancellationToken, string username)
        //{
        //    return DbSet.FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
        //}
    }
}
