using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungry.Auth;
using ZeroHungry.EF.Model;

namespace ZeroHungry.Controllers
{
    public class EmployeeController : Controller
    {
        [EmployeeAccess]
        public ActionResult Index() 
        {
            return View(); 
        }
        [HttpGet]
        [NgoAccess]
        public ActionResult EmpReg()
        {

            return View();
        }
        [HttpPost]
        [NgoAccess]
        public ActionResult EmpReg(Employee model)
        {
            ZhDb db = new ZhDb();
            db.Employees.Add(model);
            db.SaveChanges();
            return RedirectToAction("AllRequests", "CollectRequest");



        }
        [Logged]
        public ActionResult ShowRequest()
        {
            ZhDb db = new ZhDb();
            return View(db.CollectRequests.Where(cr => cr.Status == "Employee Assigned").ToList());
        }
        [EmployeeAccess]
        public ActionResult ShowCompleteRequest()
        {
            ZhDb db = new ZhDb();
            return View(db.CollectRequests.Where(cr => cr.Status == "Complete").ToList());
        }
        [EmployeeAccess]
        public ActionResult Complete(int CollectRequestId)
        {
            ZhDb db = new ZhDb();
            var collectRequest = db.CollectRequests.Find(CollectRequestId);
            collectRequest.Status = "Complete";
            db.SaveChanges();
            TempData["Msg"] = "Completed";

            return RedirectToAction("ShowRequest", "Employee");
        }
        [NgoAccess]
        public ActionResult EmployeeList()
        {
            ZhDb db = new ZhDb();
            return View(db.Employees.ToList());
        }
    }
}