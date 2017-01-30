using CodingTest.ViewModels.Core;

namespace CodingTest.ViewModels
{
    public class UserNewsLetterViewModel : IdentityColumnViewModel
    {
        public long UserId { get; set; }
        public string[] NewsLetterIds { get; set; }
    }
}