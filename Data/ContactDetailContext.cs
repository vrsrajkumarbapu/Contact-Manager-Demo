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
    public class ContactDetailContext : BaseContext<ContactDetailContext>
    {
        public DbSet<ContactDetail> ContactDetail { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Initialize ContactDetail Configuration
            modelBuilder.Configurations.Add(new ModelConfig.ContactDetailConfiguration());
        }
       
    }
}
