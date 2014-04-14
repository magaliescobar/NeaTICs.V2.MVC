using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using WebMatrix.WebData;
using NeaTICs_v2.Filters;

namespace NeaTICs_v2.Areas.Admin.Controllers
{
    [InitializeSimpleMembership]
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (!WebSecurity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string data)
        {
            JObject o = JObject.Parse(data);
            if (!WebSecurity.Login((string)o["Usuario"], (string)o["Password"], persistCookie: false))
            {
                Response.StatusCode = 500;
            }
            return View();
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index");
        }
    }
}
