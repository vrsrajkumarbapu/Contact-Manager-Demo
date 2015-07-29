using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ContactManagerDomain.Models;
namespace ContactManagerData.ModelConfig
{
    public class ContactDetailConfiguration : EntityTypeConfiguration<ContactDetail>
    {
        public ContactDetailConfiguration()
        {
            //User defined table name
            this.ToTable("ContactDetail");
            //Setting PK/Identity field
            Property(p=>p.ID).IsRequired();
            
        }
    }
}
