using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogHomekit.Web.Helpers
{
    public static class UrlHelperExtension
    {
        public static string PathUrlPost(this UrlHelper url, DateTime datePost, string urlSlug )
        {
            var result = url.RouteUrl("BlogPost",
                new
                {
                    day = datePost.Day,
                    month = datePost.Month,
                    year = datePost.Year,
                    urlSlug
                }, url.RequestContext.HttpContext.Request.Url.Scheme);
            return result;
        }
    }
}