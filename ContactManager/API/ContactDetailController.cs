using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactManagerService;
using ContactManagerDomain.Models;
namespace ContactManager.API
{
    public class ContactDetailController : ApiController
    {
        // GET api/<controller>
        ContactManagerCRUDService _svc = new ContactManagerCRUDService();
        public IEnumerable<ContactDetail> Get()
        {
            return _svc.ContactDetail;
        }

     

        // POST api/<controller>
        [HttpPost]
        public ContactDetail Post(ContactDetail contactDetail)
        {
            _svc.Add(contactDetail);
            return contactDetail;
        }

        // PUT api/<controller>/5
        [HttpPut]
        public ContactDetail Put(ContactDetail contactDetail)
        {
            _svc.update(contactDetail);
            return contactDetail;
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(int id)
        {
            _svc.Delete(id);
        }
    }
}