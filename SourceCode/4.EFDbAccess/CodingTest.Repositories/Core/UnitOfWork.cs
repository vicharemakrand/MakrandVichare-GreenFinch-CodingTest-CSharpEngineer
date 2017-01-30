using CodingTest.EntityModels.Core;
using CodingTest.IRepositories.Core;
using CodingTest.IRepositories.Identity;
using CodingTest.IRepositories.Localization;
using CodingTest.IRepositories.NewsLetter;
using CodingTest.IRepositories.UserNewsLetter;
using StructureMap.Attributes;
using System;
using System.Threading.Tasks;

namespace CodingTest.Repositories.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private DataContext dataContext;
        private INewsLetterRepository _newsLetterRepository;
        private IUserNewsLetterRepository _userNewsLetterRepository;
        private IUserRepository _userRepository;
        private IKeyGroupRepository _keyGroupRepository;
        private ILocalizationKeyRepository _localizationKeyRepository;

        #endregion

        #region Constructors

        public UnitOfWork()
        {
            this.dataContext = new DataContext();
        }

        #endregion

        #region IUnitOfWork Members

        [SetterProperty]
        public IKeyGroupRepository KeyGroupRepository
        {
            get { return _keyGroupRepository; }
            set
            {
                _keyGroupRepository = value;
                _keyGroupRepository.DbContext = dataContext;
            }
        }


        [SetterProperty]
        public ILocalizationKeyRepository LocalizationKeyRepository
        {
            get { return _localizationKeyRepository; }
            set
            {
                _localizationKeyRepository = value;
                _localizationKeyRepository.DbContext = dataContext;
            }
        }


        [SetterProperty]
        public INewsLetterRepository NewsLetterRepository
        {
            get { return _newsLetterRepository; }
            set
            {
                _newsLetterRepository = value;
                _newsLetterRepository.DbContext = dataContext;
            }
        }

        [SetterProperty]
        public IUserNewsLetterRepository UserNewsLetterRepository
        {
            get { return _userNewsLetterRepository; }
            set
            {
                _userNewsLetterRepository = value;
                _userNewsLetterRepository.DbContext = dataContext;
            }
        }

        [SetterProperty]
        public IUserRepository UserRepository
        {
            get { return _userRepository; }
            set
            {
                _userRepository = value;
                _userRepository.DbContext = dataContext;
            }
        }

        public IBaseRepository<T> SetDbContext<T>(IBaseRepository<T> repository) where T : IdentityColumnEntityModel
        {
            repository.DbContext = dataContext;
            return repository;
        }

        public int Commit()
        {
            return dataContext.Commit();
        }

        public Task<int> CommitAsync()
        {
            return dataContext.CommitAsync();
        }

        public Task<int> CommitAsync(System.Threading.CancellationToken cancellationToken)
        {
            return dataContext.CommitAsync(cancellationToken);
        }
        #endregion

        #region IDisposable Members
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
