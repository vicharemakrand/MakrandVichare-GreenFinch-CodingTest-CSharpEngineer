using CodingTest.ViewModels.Core;
using Microsoft.AspNet.Identity;

namespace CodingTest.ViewModels.Identity
{

    public class IdentityUserViewModel : BaseViewModel, IUser<long>
    {
        public long Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public string InputPassword { get; set; }

        public string NewsLetterIds { get; set; }
    }
}
