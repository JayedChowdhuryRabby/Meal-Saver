﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungry.EF.Model;

namespace ZeroHungry.Auth
{
    public class NgoAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["admin"] != null) return true;
            return false;
        }
    }
}