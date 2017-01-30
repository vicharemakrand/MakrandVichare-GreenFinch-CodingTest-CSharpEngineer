using System.ComponentModel.Composition;
using CodingTest.Common.MEF;
using CodingTest.Repositories.Core;
using CodingTest.IRepositories.Core;
using CodingTest.Repositories.Identity;
using CodingTest.IRepositories.Identity;
using CodingTest.IRepositories.UserNewsLetter;
using CodingTest.Repositories.UserNewsLetter;
using CodingTest.IRepositories.NewsLetter;
using CodingTest.Repositories.NewsLetter;
using CodingTest.IRepositories.Localization;
using CodingTest.Repositories.Localization;

namespace CodingTest.Repositories
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterType<IUnitOfWork, UnitOfWork>();
            registrar.RegisterType<IUserRepository, UserRepository>();
            registrar.RegisterType<IKeyGroupRepository, KeyGroupRepository>();
            registrar.RegisterType<ILocalizationKeyRepository, LocalizationKeyRepository>();
            registrar.RegisterType<IUserNewsLetterRepository, UserNewsLetterRepository>();
            registrar.RegisterType<INewsLetterRepository, NewsLetterRepository>();
            registrar.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
