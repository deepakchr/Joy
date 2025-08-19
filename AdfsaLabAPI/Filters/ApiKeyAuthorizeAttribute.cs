using AdfsaLabAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace AdfsaLabAPI.Filters
{
    public class ApiKeyAuthorizeAttribute : AuthorizeAttribute
    {
        private UserService _userService = new UserService();

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.TryGetValues("x-api-key", out var values))
            {
                var apiKey = values.FirstOrDefault();
                if (!string.IsNullOrEmpty(apiKey) && _userService.IsValidApiKey(apiKey))
                    return true;
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid or expired API Key");
        }
    }
}