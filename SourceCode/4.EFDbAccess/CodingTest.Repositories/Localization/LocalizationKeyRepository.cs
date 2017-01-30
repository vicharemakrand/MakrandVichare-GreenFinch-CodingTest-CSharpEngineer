using CodingTest.Repositories.Core;
using System.Collections.Generic;
using System.Linq;
using CodingTest.EntityModels.Localization;
using CodingTest.IRepositories.Localization;

namespace CodingTest.Repositories.Localization
{
    public class LocalizationKeyRepository : IdentityBaseRepository<LocalizationKeyEntityModel>, ILocalizationKeyRepository
    {

        public List<LocalizationKeyEntityModel> GetResourceByKeys(List<string> resourceKeys)
        {
            if (resourceKeys != null && resourceKeys.Count > 0)
            {
                return DbSet.Where(o => o.IsActive == true && resourceKeys.Contains(o.LocalizationKey)).ToList();
            }
            else
            {
                return new List<LocalizationKeyEntityModel>();
            }
        }
    }
}
