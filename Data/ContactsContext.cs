using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManagerDomain.Models;
using ContactManagerData.ModelConfig;
using System.Data.Entity;
namespace ContactManagerData
{
    public class ContactsContext : BaseContext<ContactsContext>
    {
        public DbSet<Contacts> Contacts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ModelConfig.ContactsConfiguration());
        }
       
    }
}
