using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlySkyServices.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            string UserID = formCollection["UserID"].ToString();
            string Pwd = formCollection["txtPassword"].ToString();
            ViewBag.LoginMessage = "";
            if(Resources.FlySkyResources.AdminUser==UserID && Resources.FlySkyResources.PwdAdmin==Pwd)
            {
                Session["UserID"] = UserID;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.LoginMessage = Resources.FlySkyResources.LoginErrorMessage;
            }
            return View();
        }
    }
}
