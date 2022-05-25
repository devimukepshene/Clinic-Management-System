using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
namespace Clinic_Management_System.Models
{
    public class login
    {
      
        public string UserName { get; set; }
        
        public string Pasword { get; set; }
    }
}