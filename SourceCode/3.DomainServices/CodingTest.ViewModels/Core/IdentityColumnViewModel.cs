using System;
using System.Web.Mvc;

namespace CodingTest.ViewModels.Core
{
    [Serializable]
    public abstract class IdentityColumnViewModel : BaseViewModel
    {
        [HiddenInput]
        public long Id { get; set; }
    }
}
