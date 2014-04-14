using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NeaTICs_v2.Models;
using NeaTICs_v2.Repositories;

namespace NeaTICs_v2.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ContactController : Controller
    {
        IContactMessageRepository _repository;

        public ContactController()
        {
            _repository = new ContactMessageRepository();
        }

        public ContactController(IContactMessageRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Admin/Contact/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(int id)
        {
            ContactMessage message = _repository.SearchById(id);
            message.IsRead = true;
            _repository.Edit(message);
            return View(message);
        }
    }
}
