using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerDomain.Models
{
    public class Contacts
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
       
        public DateTime Born { get; set; }
        [Required]
        public string Cellphone { get; set; }
        public bool IsActive { get; set; }


    }
}
