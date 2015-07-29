using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerDomain.Models
{
    //Data table mapper pattern
    public class ContactDetail
    {
       //PK Identity field
        public int ID { get; set; }
        //Contact Detail name field
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //DOB Field
        public DateTime Born { get; set; }
        //Email Field
       
        //Cell Field
        public string Cellphone { get; set; }

        public bool IsActive {get;set;}


    }
}
