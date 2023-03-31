using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungry.Auth;

namespace ZeroHungry.Controllers
{
    public class AdminController : Controller
    {
        [NgoAccess]
        public ActionResult Index()
        {
            return View();
        }
    }
}