using System;

namespace CodingTest.Utility.ParamViewModels
{
    [Serializable]
    public class SearchNewLetterViewModel
    {
        public string Publisher { get; set; }
        public string Author { get; set; }
        public long UserId { get; set; }
    }
}
