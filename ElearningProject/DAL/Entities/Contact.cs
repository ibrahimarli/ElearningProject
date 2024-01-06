using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningProject.DAL.Entities
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Adress {  get; set; }
        
        public string Email { get; set; }
    }
}