using CodingTest.IRepositories.Core;
using CodingTest.Tests.Common.MockRepositories;
using CodingTest.Tests.DomainServices.MockRepositories;
using Moq;

namespace CodingTest.Tests.Common
{
    public class UnitOfWorkGenerator
    {
        public static IUnitOfWork MockUnitOfWork()
        {
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            mockUnitOfWork.SetupProperty(a => a.NewsLetterRepository, NewsLetterRepositoryGenerator.GetMockRepository().Object);
            mockUnitOfWork.SetupProperty(a => a.UserNewsLetterRepository, UserNewsLetterRepositoryGenerator.GetMockRepository().Object);
            mockUnitOfWork.SetupProperty(a => a.UserRepository, UserRepositoryGenerator.GetMockRepository().Object);

            return mockUnitOfWork.Object;
        }
    }
}
