using CodingTest.ViewModels.Core;
using System;

namespace CodingTest.ViewModels
{
    [Serializable]
    public class NewsLetterViewModel : IdentityColumnViewModel
    {
        public string Title { get; set; }

        public string Publisher { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public bool IsSubscribed { get; set; }

    }
}
