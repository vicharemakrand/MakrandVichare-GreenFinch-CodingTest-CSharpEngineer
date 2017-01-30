using CodingTest.ViewModels.Core;
using System;

namespace CodingTest.ViewModels
{
    [Serializable]
    public class LocalizationKeyViewModel : IdentityColumnViewModel
    {
        public string LocalizationKey { get; set; }
        public string EnglishValue { get; set; }
        public string IrishValue { get; set; }
        public bool IsActive { get; set; }
    }
}
