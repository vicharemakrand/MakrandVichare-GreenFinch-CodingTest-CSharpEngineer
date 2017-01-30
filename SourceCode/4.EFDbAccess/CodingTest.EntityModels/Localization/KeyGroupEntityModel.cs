using CodingTest.EntityModels.Core;

namespace CodingTest.EntityModels.Localization
{
    public class KeyGroupEntityModel : IdentityColumnEntityModel
    {

        #region Scalar Properties
        public string KeyGroup { get; set; }
        public string LocalizationKeys { get; set; }

        #endregion
    }
}
