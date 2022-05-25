using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;


namespace Clinic_Management_System.Models
{
    public class Schedule
    {
        [Key]
        public int PatientID { get; set; }
        public string Specialization { get; set; }
        public string Docter { get; set; }
        public string VisitDate { get; set; }
        public string AppointmentTime { get; set; }
    }
}
