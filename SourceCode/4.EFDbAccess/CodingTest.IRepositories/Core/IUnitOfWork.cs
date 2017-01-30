using CodingTest.EntityModels.Core;
using CodingTest.IRepositories.Identity;
using CodingTest.IRepositories.Localization;
using CodingTest.IRepositories.NewsLetter;
using CodingTest.IRepositories.UserNewsLetter;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodingTest.IRepositories.Core
{
    public interface IUnitOfWork : IDisposable
    {
        #region Methods
        int Commit();
        Task<int> CommitAsync();
        Task<int> CommitAsync(CancellationToken cancellationToken);
        #endregion
        INewsLetterRepository NewsLetterRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        IUserNewsLetterRepository UserNewsLetterRepository { get; set; }
        IKeyGroupRepository KeyGroupRepository { get; set; }
        ILocalizationKeyRepository LocalizationKeyRepository { get; set; }

        IBaseRepository<T> SetDbContext<T>(IBaseRepository<T> repository) where T : IdentityColumnEntityModel;

    }
}
