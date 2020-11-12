// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System;
using Microsoft.AspNetCore.Mvc.Filters;
using StackExchange.Redis;

namespace Start_App
{
    public class AuthenticationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string token = context.HttpContext.Request.Headers["AuthToken"];// get the authentication token from request headers
            if(!string.IsNullOrEmpty(token))
            {
                // get user information from cache server ex. redis/memcached
                
            }
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
