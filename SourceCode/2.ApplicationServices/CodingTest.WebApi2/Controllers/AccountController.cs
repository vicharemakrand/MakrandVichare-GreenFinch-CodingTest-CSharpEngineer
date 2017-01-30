using CodingTest.Utility;
using CodingTest.ViewModels.Identity;
using CodingTest.WebApi2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CodingTest.WebApi2.Controllers
{

    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private UserManager<IdentityUserViewModel, long> _userManager;

        private IAuthenticationManager AuthenticationManager
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        private UserManager<IdentityUserViewModel, long> UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<UserManager<IdentityUserViewModel, long>>();
            }
             set
            {
                _userManager = value;
            }
        }

        public AccountController(UserManager<IdentityUserViewModel, long> userManager)
        {
            this.UserManager = userManager;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        [SkipFilter]
        public async Task<IHttpActionResult> Register(RegisterBindingModel bindingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new IdentityUserViewModel { UserName = bindingModel.Email, Email = bindingModel.Email , NewsLetterIds = bindingModel.NewsLetterIds };
            try
            {
                IdentityResult result = await UserManager.CreateAsync(user, bindingModel.Password);

                IHttpActionResult errorResult = GetErrorResult(result);

                if (errorResult != null)
                {
                    return errorResult;
                }

                return Ok(new { message = AppMessages.SIGNUP_SUCCESS_REDIRECT_TIMEOUT_MESSAGE });

            } catch(Exception ex)
            {
                if(CheckUniqueKeyException(ex))
                {
                    return BadRequest(AppMessages.SIGNUP_ERROR_DUPLICATE_KEY_MESSAGE);
                }

                return InternalServerError(ex);
            }
        }

        public virtual bool CheckUniqueKeyException(Exception exception)
        {
            bool result = false;
            DbUpdateException dbUpdateEx = exception as DbUpdateException;
            if (dbUpdateEx != null)
            {
                if (dbUpdateEx != null
                        && dbUpdateEx.InnerException != null
                        && dbUpdateEx.InnerException.InnerException != null)
                {
                    SqlException sqlException = dbUpdateEx.InnerException.InnerException as SqlException;
                    if (sqlException != null)
                    {
                        switch (sqlException.Number)
                        {
                            case 2627:  // Unique constraint error
                            case 547:   // Constraint check violation
                            case 2601:  // Duplicated key row error
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
            }

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UserManager.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Helpers

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        #endregion
    }

}
