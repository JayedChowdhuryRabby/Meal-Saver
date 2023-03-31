using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungry.Auth;
using ZeroHungry.EF.Model;

namespace ZeroHungry.Controllers
{
    public class CollectRequestController : Controller
    {
        // GET: CollectRequest
        [HttpGet]
        [RestaurentAccess]
        public ActionResult CreateRequest()
        {

            return View();
        }
        [HttpPost]
        [RestaurentAccess]
        public ActionResult CreateRequest(CollectRequest model)
        {
          
       
            ZhDb db = new ZhDb();
            model.Status = "Pending";
            db.CollectRequests.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Restaurant");

          
        }
        [Logged]
        public ActionResult AllRequests()
        {
            ZhDb db = new ZhDb();
            return View(db.CollectRequests.ToList());
        }
    }
}