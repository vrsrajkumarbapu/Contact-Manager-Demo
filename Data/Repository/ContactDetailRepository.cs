using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManagerDomain.Models;
using ContactManagerDomain.RepositoryInterfaces;

namespace ContactManagerData.Repository
{
    public class ContactDetailRepository : IContactDetailRepository
    {
        public void Add(ContactDetail contactDetail)
        {
            if (contactDetail == null)
            {
                throw new NotImplementedException("Contact Detail not intialized");
            }
            using (ContactDetailContext ctx = new ContactDetailContext())
            {
                ctx.ContactDetail.Add(contactDetail);
                ctx.SaveChanges();

            }
        }

        public void Update(ContactDetail contactDetail)
        {

            using (ContactDetailContext ctx = new ContactDetailContext())
            {
                var contactDetailEntity = ctx.ContactDetail.SingleOrDefault(p => p.ID == contactDetail.ID);
                if (contactDetailEntity == null)
                {
                    throw new NotImplementedException("Person not intialized");
                }
                ctx.Entry(contactDetailEntity).CurrentValues.SetValues(contactDetail);
                ctx.SaveChanges();

            }
        }

        public void Delete(int id)
        {

            using (ContactDetailContext ctx = new ContactDetailContext())
            {
                var contactDetailEntity = ctx.ContactDetail.SingleOrDefault(p => p.ID == id);
                if (contactDetailEntity == null)
                {
                    throw new NotImplementedException("Person not intialized");
                }
                ctx.ContactDetail.Remove(contactDetailEntity);
                ctx.SaveChanges();

            }
        }
        
        public ICollection<ContactDetail> ContactDetail()
        {
            using (ContactDetailContext ctx = new ContactDetailContext())  
           {
               return ctx.ContactDetail.ToList();
           }
        }
    }
}
