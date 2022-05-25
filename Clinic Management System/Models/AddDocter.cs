using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Clinic_Management_System.Models
{
    public class AddDocter
    {
        [Key]
        public int DocterID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Specialization { get; set; }
        public string Visiting_Hours { get; set; }
    }
}
