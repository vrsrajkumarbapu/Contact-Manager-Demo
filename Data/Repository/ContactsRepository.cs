using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManagerDomain.Models;
using ContactManagerDomain.RepositoryInterfaces;

namespace ContactManagerData.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        public void Add(Contacts contacts)
        {
            if (contacts == null)
            {
                throw new NotImplementedException("Contact Detail not intialized");
            }
            using (ContactsContext ctx = new ContactsContext())
            {
                ctx.Contacts.Add(contacts);
                ctx.SaveChanges();

            }
        }

        public void Update(Contacts contacts)
        {

            using (ContactsContext ctx = new ContactsContext())
            {
                var ContactsEntity = ctx.Contacts.SingleOrDefault(p => p.ID == contacts.ID);
                if (ContactsEntity == null)
                {
                    throw new NotImplementedException("Person not intialized");
                }
                ctx.Entry(ContactsEntity).CurrentValues.SetValues(contacts);
                ctx.SaveChanges();

            }
        }

        public void Delete(int id)
        {

            using (ContactsContext ctx = new ContactsContext())
            {
                var ContactsEntity = ctx.Contacts.SingleOrDefault(p => p.ID == id);
                if (ContactsEntity == null)
                {
                    throw new NotImplementedException("Person not intialized");
                }
                ctx.Contacts.Remove(ContactsEntity);
                ctx.SaveChanges();

            }
        }
        
        public ICollection<Contacts> Contacts()
        {
            using (ContactsContext ctx = new ContactsContext())  
           {
               return ctx.Contacts.ToList();
           }
        }
    }
}
