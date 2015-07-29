using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  ContactManagerDomain.Models;
namespace ContactManagerDomain.RepositoryInterfaces
{

    public interface IContactDetailRepository
    {
        void Add(ContactDetail contact);
        void Update(ContactDetail contact);
        void Delete(int id);
        ICollection<ContactDetail> ContactDetail();
    }
}
