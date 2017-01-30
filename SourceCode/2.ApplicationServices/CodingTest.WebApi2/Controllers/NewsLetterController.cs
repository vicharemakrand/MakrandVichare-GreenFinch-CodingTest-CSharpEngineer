using CodingTest.IDomainServices.Services;
using CodingTest.Utility.ParamViewModels;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodingTest.WebApi2.Controllers
{
    [RoutePrefix("api/NewsLetters")]
    public class NewsLetterController : ApiController
    {
        private readonly INewsLetterService newsLetterService;

        public NewsLetterController(INewsLetterService newsLetterService)
        {
            this.newsLetterService = newsLetterService;
        }

        [Route("GetTopNewsLetters")]
        [HttpGet]
        public HttpResponseMessage GetTopNewsLetters(long userId)
        {
            try
            {
                var response = newsLetterService.GetTopNewsLetters(userId);
                return Request.CreateResponse(HttpStatusCode.OK, new { response.ViewModels, message = response.Message });
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("GetNewsLetters")]
        [HttpGet]
        public HttpResponseMessage GetNewsLetters([FromUri]SearchNewLetterViewModel searchParam)
        {
            try
            {
                var response = newsLetterService.GetNewsLetters(searchParam);
                return Request.CreateResponse(HttpStatusCode.OK, new { response.ViewModels, message = response.Message });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
