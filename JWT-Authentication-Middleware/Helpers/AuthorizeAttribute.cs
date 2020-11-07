using JWT_Authentication_Middleware.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace JWT_Authentication_Middleware.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            User user = (User)context.HttpContext.Items["User"];
            if(user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { Message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}

/*
 * The custom authorize attribute is added to controller action methods that require the user to be authenticated.
 * 
 * Authorization is performed by the OnAuthorization method which checks if there is an authenticated user attached to the current request (context.HttpContext.Items["User"]). 
 * An authenticated user is attached by the custom jwt middleware if the request contains a valid JWT access token.
 * On successful authorization no action is taken and the request is passed through to the controller action method, if authorization fails a 401 Unauthorized response is returned.
 * 
*/
