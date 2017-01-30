using CodingTest.EntityModels.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace CodingTest.IRepositories.Core
{
    public interface IDataContext : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();
        Task<int> CommitAsync(CancellationToken cancellationToken);
        IDbSet<T> DbSet<T>() where T : BaseEntityModel;
        DbEntityEntry Entry<T>(T entity) where T : BaseEntityModel;

    }
}
