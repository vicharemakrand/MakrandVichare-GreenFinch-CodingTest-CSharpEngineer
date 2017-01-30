using CodingTest.Utility;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;

namespace CodingTest.WebApi2.Controllers
{
    [RoutePrefix("api/Antiforgerytoken")]
    public class AntiForgeryTokenController : ApiController
    {

        [HttpGet]
        [Route("GetAntiForgeryToken")]
        public HttpResponseMessage GetAntiForgeryToken()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            HttpCookie cookie = HttpContext.Current.Request.Cookies[AppConstants.XsrfCookie];
            string oldCookieToken = cookie == null ? "" : cookie.Value;
            string cookieToken;
            string formToken;
            AntiForgery.GetTokens(oldCookieToken, out cookieToken, out formToken);

            var content = new { FormToken = formToken , CookieToken = cookieToken };

            response.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

            if (!string.IsNullOrEmpty(cookieToken))
            {
                CookieHeaderValue cookieData = new CookieHeaderValue(AppConstants.XsrfCookie, cookieToken);
                cookieData.Expires = DateTimeOffset.Now.AddMinutes(10);
                cookieData.Domain = Request.RequestUri.Host;
                cookieData.Path = "/";
                response.Headers.AddCookies(new CookieHeaderValue[] { cookieData });
            }

            return response;
        }
    }
}
