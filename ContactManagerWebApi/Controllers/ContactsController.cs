using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactManagerDomain.Models;
using ContactManagerDomain.RepositoryInterfaces;
using ContactManagerData.Repository;
namespace ContactManagerWebApi.Controllers
{
    public class ContactsController : BaseController<Contacts, ContactsRepository>
    {

        IContactsRepository _repo = new ContactsRepository();
        public IEnumerable<Contacts> Get()
        {
            return _repo.Contacts();
        }
        [HttpPost]
        public void Add(Contacts contactDetail)
        {
            if (ModelState.IsValid)
            _repo.Add(contactDetail);
        }
         [HttpPut]
        public void update(Contacts contactDetail)
        {
             if(ModelState.IsValid)
            _repo.Update(contactDetail);
        }
         [HttpDelete]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
        public ICollection<Contacts> ContactDetail
        {
            get { return _repo.Contacts(); }
        }
    }
}