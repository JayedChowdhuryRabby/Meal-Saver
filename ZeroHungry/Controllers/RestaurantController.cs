using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungry.Auth;
using ZeroHungry.EF.Model;
using ZeroHungry.Models;

namespace ZeroHungry.Controllers
{
    public class RestaurantController : Controller
    {
        [RestaurentAccess]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                ZhDb db = new ZhDb();
                var user = (from u in db.Restaurants
                            where u.Name.Equals(login.Name)
                            && u.Password.Equals(login.Password)
                            select u).SingleOrDefault();
                var emp = (from u in db.Employees
                            where u.Name.Equals(login.Name)
                            && u.Password.Equals(login.Password)
                            select u).SingleOrDefault();

                var admin = (from u in db.Admins
                           where u.Name.Equals(login.Name)
                           && u.Password.Equals(login.Password)
                           select u).SingleOrDefault();


                if (user != null)
                {
                    Session["user"] = user;
                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null)
                    {
                        return Redirect(retUrl);
                    }
                    return RedirectToAction("Index", "Restaurant");
                }
                if (emp != null)
                {
                    Session["emp"] = emp;
                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null)
                    {
                        return Redirect(retUrl);
                    }
                    return RedirectToAction("Index", "Employee");
                }
                if (admin != null)
                {
                    Session["admin"] = admin;
                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null)
                    {
                        return Redirect(retUrl);
                    }
                    return RedirectToAction("Index", "Admin");
                }
            }
            TempData["Msg"] = "Username Password invalid";
            return View(login);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Restaurant");
        }

        [HttpGet]
        public ActionResult resReg()
        {

            return View();
        }
        [HttpPost]
        public ActionResult resReg(Restaurant model)
        {
            ZhDb db = new ZhDb();
            db.Restaurants.Add(model);
            db.SaveChanges();
            return RedirectToAction("Login", "Restaurant");



        }
       
        [NgoAccess]
        public ActionResult AddCart(int CollectRequestId)
        {
            ZhDb db = new ZhDb();
            var collectRequest = db.CollectRequests.Find(CollectRequestId);
            collectRequest.Status = "Accepted";
            db.SaveChanges();
            TempData["Msg"] = "Collect Request Accepted";

            return RedirectToAction("AllRequests", "CollectRequest");
        }
        [NgoAccess]
        public ActionResult ShowAceptedRequest()
        {
            ZhDb db = new ZhDb();
            return View(db.CollectRequests.Where(cr => cr.Status == "Accepted").ToList());
        }
        [NgoAccess]
        public ActionResult Cancel(int CollectRequestId)
        {
            ZhDb db = new ZhDb();
            var collectRequest = db.CollectRequests.Find(CollectRequestId);
            collectRequest.Status = "Cancelled By NGO";
            db.SaveChanges();
            TempData["Msg"] = "Collect Request Cancelled";

            return RedirectToAction("AllRequests", "CollectRequest");
        }
        [HttpGet] [NgoAccess]
        public ActionResult Assign()
        {
            return View();
        }
        [NgoAccess]
        [HttpPost]
        public ActionResult Assign(int CollectRequestId, int EmployeeId)
        {
            ZhDb db = new ZhDb();
            var collectRequest = db.CollectRequests.Find(CollectRequestId);
            collectRequest.Status = "Employee Assigned";
            collectRequest.EmployeeId=EmployeeId;
            db.SaveChanges();
            TempData["Msg"] = "Employee Assigned";
            return RedirectToAction("ShowAceptedRequest", "Restaurant");
        }
        [Logged]
        public ActionResult RestaurentList()
        {
            ZhDb db = new ZhDb();
            return View(db.Restaurants.ToList());
        }

    }
   
}