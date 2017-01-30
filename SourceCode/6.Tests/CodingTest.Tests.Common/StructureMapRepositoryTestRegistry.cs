using CrossOver.IRepositories.Core;
using CrossOver.IRepositories.Identity;
using CrossOver.IRepositories.SearchBook;
using CrossOver.IRepositories.UserDemand;
using CrossOver.Tests.Common.MockRepositories;
using CrossOver.Tests.DomainServices.MockRepositories;
using StructureMap;

namespace CrossOver.Tests.Common
{
    public class StructureMapRepositoryTestRegistry : Registry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyConfigurationRegistry"/> class.
        /// </summary>
        public StructureMapRepositoryTestRegistry()
        {
            For<IUserRepository>().Use(UserRepositoryGenerator.GetMockRepository().Object);
            For<IBookRepository>().Use(BookRepositoryGenerator.GetMockRepository().Object);
            For<IUserDemandRepository>().Use(UserDemandRepositoryGenerator.GetMockRepository().Object);
            For<IUnitOfWork>().Use(UnitOfWorkGenerator.MockUnitOfWork());

        }
    }
}
