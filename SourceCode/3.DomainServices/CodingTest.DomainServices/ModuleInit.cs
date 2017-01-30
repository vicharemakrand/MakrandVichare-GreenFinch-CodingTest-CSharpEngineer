using CodingTest.Common.MEF;
using CodingTest.DomainServices.IdentityStores;
using CodingTest.IDomainServices.Services;
using CodingTest.ViewModels.Identity;
using Microsoft.AspNet.Identity;
using System.ComponentModel.Composition;

namespace CodingTest.DomainServices
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterType<INewsLetterService, NewsLetterService>();
            registrar.RegisterType<ILocalizationService, LocalizationService>();
            registrar.RegisterType<IUserNewsLetterService, UserNewsLetterService>();
            registrar.RegisterType(typeof(IUserStore<IdentityUserViewModel, long>), typeof(CustomUserStore));
        }
    }
}
