using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;


namespace Clinic_Management_System.Models
{
    public class CancelAppointment
    {
        public int PatientID { get; set; }
        public string VisitDate { get; set; }
        
    }
}

    

