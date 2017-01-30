using CodingTest.EntityModels.Core;

namespace CodingTest.EntityModels.Localization
{
    public class LocalizationKeyEntityModel : IdentityColumnEntityModel
    {

        #region Scalar Properties
        public string LocalizationKey { get; set; }
        public string EnglishValue { get; set; }
        public string IrishValue { get; set; }
        public bool IsActive { get; set; }
        #endregion
    }
}
