using CodingTest.EntityModels.Identity;
using CodingTest.IRepositories.Core;
using System.Threading;
using System.Threading.Tasks;

namespace CodingTest.IRepositories.Identity
{
    public interface IUserRepository  : IBaseRepository<UserEntityModel>
    {
        //UserEntityModel FindByUserName(string username);
        //Task<UserEntityModel> FindByUserNameAsync(string username);
        //Task<UserEntityModel> FindByUserNameAsync(CancellationToken cancellationToken, string username);

        UserEntityModel FindByEmail(string email);
        Task<UserEntityModel> FindByEmailAsync(string email);
        Task<UserEntityModel> FindByEmailAsync(CancellationToken cancellationToken, string email);
    }
}
