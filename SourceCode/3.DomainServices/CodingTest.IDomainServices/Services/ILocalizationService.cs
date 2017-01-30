using CodingTest.EntityModels.Localization;
using CodingTest.IDomainServices.Core;
using CodingTest.ViewModels;
using System.Collections.Generic;

namespace CodingTest.IDomainServices.Services
{
    public interface ILocalizationService : IBaseService<LocalizationKeyEntityModel, LocalizationKeyViewModel>
    {
        Dictionary<string, string> GetLocalizations(string keyGroup, string languageCode);
    }
}
