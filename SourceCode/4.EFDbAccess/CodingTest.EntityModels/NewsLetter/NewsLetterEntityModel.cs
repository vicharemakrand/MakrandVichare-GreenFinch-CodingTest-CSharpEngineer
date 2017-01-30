using CodingTest.EntityModels.Core;
using System;

namespace CodingTest.EntityModels
{
    [Serializable]
    public class NewsLetterEntityModel : IdentityColumnEntityModel
    {
        public string Title { get; set; }

        public string Publisher { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

    }
}
