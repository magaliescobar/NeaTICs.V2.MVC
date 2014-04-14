using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NeaTICs_v2.Helpers;
using NeaTICs_v2.Models;
using Newtonsoft.Json.Linq;
using NeaTICs_v2.Repositories;

namespace NeaTICs_v2.Controllers
{
    public class HomeController : BaseController
    {
        private IContactMessageRepository _repositoryContact;

        public HomeController()
        {
            _repositoryContact = new ContactMessageRepository();
        }

        public HomeController(IContactMessageRepository repository)
        {
            _repositoryContact = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult PoloITChaco()
        {
            return View();
        }

        public ActionResult Informatorio()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string data)
        {
            JObject o = JObject.Parse(data);
            string Name = (string)o["Name"];
            string Email = (string)o["Email"];
            string Subject = (string)o["Subject"];
            string Message = (string)o["Message"];
            ContactMessage CMessage = new ContactMessage() { Name = Name, Email = Email, Date = DateTime.Now, Subject = Subject, Message = Message, IsRead = false };
            try
            {
                _repositoryContact.New(CMessage);
                Response.StatusCode = 200;
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
            }

            return View();
        }

        public ActionResult SetCulture(string culture)
        {
            culture = CultureHelper.GetImplementedCulture(culture);
            RouteData.Values["culture"] = culture;
            return RedirectToAction("Index");
        }

        public JsonResult FillCarousel()
        {
            List<Dictionary<string, object>> NewsList = FacebookHelper.GetNewsWithImages(25);
            return Json(NewsList, JsonRequestBehavior.AllowGet);
        }

    }
}
