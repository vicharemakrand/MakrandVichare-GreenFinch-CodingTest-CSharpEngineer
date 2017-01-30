using CodingTest.EntityModels.Core;
using System.Collections.Generic;

namespace CodingTest.EntityModels.Identity
{
    public class UserEntityModel : BaseEntityModel
    {
        #region Fields
        private ICollection<ClaimEntityModel> _claims;

        #endregion

        #region Scalar Properties
        public long UserId { get; set; }
        //public string UserName { get; set; }
        public string Email { get; set; }

        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        #endregion

        #region Navigation Properties
        public virtual ICollection<ClaimEntityModel> Claims
        {
            get { return _claims ?? (_claims = new List<ClaimEntityModel>()); }
            set { _claims = value; }
        }

        public virtual UserNewsLetterEntityModel UserNewsLetter { get; set; }
        #endregion
    }
}
