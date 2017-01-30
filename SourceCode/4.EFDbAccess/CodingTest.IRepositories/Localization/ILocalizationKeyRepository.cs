using CodingTest.EntityModels.Localization;
using CodingTest.IRepositories.Core;
using System.Collections.Generic;

namespace CodingTest.IRepositories.Localization
{
    public interface ILocalizationKeyRepository : IIdentityBaseRepository<LocalizationKeyEntityModel>
    {
        List<LocalizationKeyEntityModel> GetResourceByKeys(List<string> resourceKeys);
    }
}
