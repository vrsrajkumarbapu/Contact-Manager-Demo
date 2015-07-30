using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ContactManagerDomain.Models;
namespace ContactManagerData.ModelConfig
{
    public class ContactsConfiguration : EntityTypeConfiguration<Contacts>
    {
        public ContactsConfiguration()
        {
           this.ToTable("Contacts");
           Property(p=>p.ID).IsRequired();
            
        }
    }
}
