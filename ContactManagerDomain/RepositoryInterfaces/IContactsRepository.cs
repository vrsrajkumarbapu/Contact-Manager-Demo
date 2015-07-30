using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  ContactManagerDomain.Models;
namespace ContactManagerDomain.RepositoryInterfaces
{

    public interface IContactsRepository
    {
        void Add(Contacts contact);
        void Update(Contacts contact);
        void Delete(int id);
        ICollection<Contacts> Contacts();
    }
}
