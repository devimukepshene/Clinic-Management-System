using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;
using Clinic_Management_System.Models;
using System.Data;

namespace Clinic_Management_System.DAL
{
    public class ClinicDAL
    {
        public string cnn = " ";

        public ClinicDAL()
        {

            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:ClinicConn").Value;
        }
        public int Newdocdetails(AddDocter doc)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Newdocdetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Doc_Fname", doc.FirstName);
            cmd.Parameters.AddWithValue("@Doc_Lname", doc.LastName);
            cmd.Parameters.AddWithValue("@Gen", doc.Gender);
            cmd.Parameters.AddWithValue("@Spl", doc.Specialization);
            cmd.Parameters.AddWithValue("@hrs", doc.Visiting_Hours);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        } 
           public List<AddDocter> Docterinfo()
            {
                List<AddDocter> Docterinfos = new List<AddDocter>();
                using (SqlConnection con = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand("Docterinfo", con))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        IDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Docterinfos.Add(new AddDocter()
                            {
                                DocterID = int.Parse(reader["DocterID"].ToString()),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                Specialization = reader["Specialization"].ToString(),
                                Visiting_Hours = reader["Visiting_Hours"].ToString()

                            }); ;
                        }
                    }
                }
                return Docterinfos;
            }
        

        public int NewPatientdetails(AddPatient pat)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("NewPatientDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@patientid", pat.PatientID);
            cmd.Parameters.AddWithValue("@pat_Fname", pat.FirstName);
            cmd.Parameters.AddWithValue("@Pat_Lname", pat.LastName);
            cmd.Parameters.AddWithValue("@gen", pat.Gender);
            cmd.Parameters.AddWithValue("@age", pat.Age);
            cmd.Parameters.AddWithValue("@dob", pat.DOB);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int loginvalidate(login log)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("loginvalidate", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", log.UserName);
            cmd.Parameters.AddWithValue("@pass", log.Pasword);
            con.Open();
            IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return (1);
            //int result = cmd.ExecuteNonQuery();
            con.Close();
            return (0);
            
            
        }
        public List<AddPatient> Patientinfos()
        {
            List<AddPatient> Patientinfos = new List<AddPatient>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("Patientinfo", con))
                {
                    if (con.State == ConnectionState.Closed)
                    con.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Patientinfos.Add(new AddPatient()
                        {
                            PatientID = int.Parse(reader["PatientID"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Age = reader["Age"].ToString(),
                            DOB = reader["DOB"].ToString()

                        }); ;
                    }
                }
            }
            return Patientinfos;
        }

        public int Scheduledetails(Schedule sch)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Scheduledetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@patientid", sch.PatientID);
            cmd.Parameters.AddWithValue("@spl", sch.Specialization);
            cmd.Parameters.AddWithValue("@doc", sch.Docter);
            cmd.Parameters.AddWithValue("@visit", sch.VisitDate);
            cmd.Parameters.AddWithValue("@v_time", sch.AppointmentTime);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public List<Schedule> Scheduleinfo()
        {
            List<Schedule> scheduleinfos = new List<Schedule>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("Scheduleinfo", con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        scheduleinfos.Add(new Schedule()
                        {
                            PatientID = int.Parse(reader["PatientID"].ToString()),
                            Specialization = reader["Specialization"].ToString(),
                            Docter = reader["Docter"].ToString(),
                            VisitDate = reader["VisitDate"].ToString(),
                            AppointmentTime = reader["AppointmentTime"].ToString(),
                        }); ;
                    }
                }
            }
            return scheduleinfos;
        }

        public int CancelAppointment(CancelAppointment cat)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("CancelAppointment", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@patientid", cat.PatientID);
            cmd.Parameters.AddWithValue("@visit", cat.VisitDate);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}




