using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NeaTICs_v2.Repositories;
using NeaTICs_v2.Models;

namespace NeaTICs_v2.Areas.Admin.Controllers
{
    public class ContactMessageController : ApiController
    {
        private IContactMessageRepository _repository;

        public ContactMessageController()
        {
            _repository = new ContactMessageRepository();
        }

        public ContactMessageController(IContactMessageRepository repositoryQuestion)
        {
            _repository = repositoryQuestion;
        }

        // GET api/question
        public IEnumerable<ContactMessage> Get()
        {
            IList<ContactMessage> ContactMessages = _repository.ObtainList().ToList();
            return ContactMessages.AsEnumerable();
        }

        // GET api/question/5
        public ContactMessage Get(int id)
        {
            return _repository.SearchById(id);
        }
    }
}
