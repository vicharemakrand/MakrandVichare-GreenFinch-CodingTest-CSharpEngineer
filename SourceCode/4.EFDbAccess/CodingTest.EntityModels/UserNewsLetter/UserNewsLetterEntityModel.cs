using CodingTest.EntityModels.Core;
using CodingTest.EntityModels.Identity;

namespace CodingTest.EntityModels
{
    public class UserNewsLetterEntityModel : IdentityColumnEntityModel
    {

        public long UserId { get; set; }
        public string NewsLetterIds { get; set; }

        #region Navigation Properties

        public virtual UserEntityModel User { get; set; }
        
        #endregion
    }
}