using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NeaTICs_v2.Models;

namespace NeaTICs_v2.Repositories
{
    public interface IContactMessageRepository
    {
        void New(ContactMessage message);
        ContactMessage SearchById(int id);
        void Edit(ContactMessage message);
        IEnumerable<ContactMessage> ObtainList();
    }
}