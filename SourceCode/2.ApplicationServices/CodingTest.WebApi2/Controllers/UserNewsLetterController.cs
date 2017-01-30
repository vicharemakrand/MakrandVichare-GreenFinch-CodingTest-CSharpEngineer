using CodingTest.IDomainServices.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodingTest.WebApi2.Controllers
{
    [Authorize]
    public class UserNewsLetterController : ApiController
    {
        private readonly IUserNewsLetterService userNewsLetterService;

        public UserNewsLetterController(IUserNewsLetterService userNewsLetterService)
        {
            this.userNewsLetterService = userNewsLetterService;
        }

        [HttpGet]
        public HttpResponseMessage GetUserNewsLetters(long userId)
        {
            var response = userNewsLetterService.GetUserNewsLetters(userId);
            return Request.CreateResponse(HttpStatusCode.OK, new { response.ViewModels, message = response.Message });
        }

    }
}
