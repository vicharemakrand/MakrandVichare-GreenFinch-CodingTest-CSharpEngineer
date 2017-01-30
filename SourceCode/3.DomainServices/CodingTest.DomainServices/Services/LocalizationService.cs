using CodingTest.DomainServices.Core;
using CodingTest.IDomainServices.Services;
using CodingTest.ViewModels;
using CodingTest.EntityModels.Localization;
using System.Collections.Generic;
using System;
using System.Linq;
using CodingTest.Utility;
using CodingTest.InfraStructure.Logging;

namespace CodingTest.DomainServices
{
    public class LocalizationService : BaseService<LocalizationKeyEntityModel, LocalizationKeyViewModel>, ILocalizationService
    {
        public Dictionary<string,string> GetLocalizations(string keyGroup, string languageCode)
        {
            var localizationKeys = new Dictionary<string, string>();
            try
            {
                var resourceKeyModel = UnitOfWork.KeyGroupRepository.GetResourceKeysByGroup(keyGroup);
                if(resourceKeyModel != null )
                {
                    var resourceKeys = resourceKeyModel.LocalizationKeys.Split(',').ToList();
                    var resourceValues = UnitOfWork.LocalizationKeyRepository.GetResourceByKeys(resourceKeys);
                    if (resourceValues != null && resourceValues.Count > 0)
                    {
                        if (languageCode == AppConstants.IrishLanguage)
                        {
                            localizationKeys = resourceValues.ToDictionary(o => o.LocalizationKey, o => o.IrishValue);
                        }
                        else
                        {
                            localizationKeys = resourceValues.ToDictionary(o => o.LocalizationKey, o => o.EnglishValue);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                NLogLogger.Instance.Log(ex.Message);
            }
            return localizationKeys;
        }

    }
}
