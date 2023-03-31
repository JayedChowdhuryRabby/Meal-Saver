using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZeroHungry.Auth
{
    public class Logged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["user"] != null || httpContext.Session["admin"] != null || httpContext.Session["emp"] != null) return true;
            return false;
        }

    }
}