using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Clinic_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Clinic_Management_System.DAL;


namespace Clinic_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult IndexPage(login log)
        {
            if (ModelState.IsValid)
            {
            ClinicDAL obj = new ClinicDAL();
            int result = obj.loginvalidate(log);
            if (result == 1)
            //if (ModelState.IsValid)
            {
                return RedirectToAction("Home");
            }
            else
            {
               return View("Invalid1");

           }

        }
            else
           {
              return View("Home");
            }
            //if (ModelState.IsValid)
            //{
            //    return View("Home");
            //}
            //return View("Index");

        }
        [Route("Home/AddDocter")]

        public IActionResult AddDocter()
        {
            return View("AddDocter");
        }
        public IActionResult Newdocdetails1(AddDocter doc)
        {
                ClinicDAL obj = new ClinicDAL();
                int result = obj.Newdocdetails(doc);
                if (result == 1)
                    return RedirectToAction("Home");
                else
                    return View("AddDocter");
        }
        [Route("Home/AddPatient")]
        public IActionResult AddPatient()
        {
            return View();
        }
        public IActionResult NewPatientDetails1(AddPatient pat)
        { 
                ClinicDAL obj = new ClinicDAL();
                int result = obj.NewPatientdetails(pat);
                if (result == 1)
                    return RedirectToAction("Home");
                else
                    return View("AddPatient");
            }
   
                public IActionResult Schedule()
        {
            return View();
        }
        
        public IActionResult Scheduledetails(Schedule sch)
        {
            ClinicDAL obj = new ClinicDAL();
            int result = obj.Scheduledetails(sch);
            if (result == 1)
                return RedirectToAction("Home");
            else
                return View("Schedule");
        }
        public IActionResult CancelAppointment()
        {
            return View();
        }
        public IActionResult CancelAppointment1(CancelAppointment cat)
        {
            ClinicDAL obj = new ClinicDAL();
            int result = obj.CancelAppointment(cat);
            if (result == 1)
                return View("Home");
            else
                return View("CancelAppointment");
            //if (ModelState.IsValid)
            //{
            //    return Content("Cancelled");
            //}
            //return View("CancelAppointment");
        }
        public IActionResult Logout()
        {
            return View("Index"); 
        }
        public IActionResult Docterinfo(AddDocter docterinfo)
        {
            ClinicDAL obj = new ClinicDAL();
            List<AddDocter> Docterinfo = new List<AddDocter>();
            Docterinfo = obj.Docterinfo();
            return View(Docterinfo);
        }
        public IActionResult Patientinfo(AddPatient patientinfo)
        {
            ClinicDAL obj = new ClinicDAL();
            List<AddPatient> Patientinfo = new List<AddPatient>();
            Patientinfo = obj.Patientinfos();
            return View(Patientinfo);
        }

        public IActionResult Scheduleinfo(Schedule scheduleinfo)
        {
            ClinicDAL obj = new ClinicDAL();
            List<Schedule> Scheduleinfo = new List<Schedule>();
            Scheduleinfo = obj.Scheduleinfo();
            return View(Scheduleinfo);
        }
        //public IActionResult AddDocter()
        //{
        //    return View();
        //}

        //public IActionResult Newdocdetails(AddDocter doc)
        // {
        //    ClinicDAL obj = new ClinicDAL();
        //    int result = obj.Newdocdetails(doc);
        //    if (result == 1)
        //        return RedirectToAction("Index");
        //    else
        //        return View("AddDocter");

        // }
        // public IActionResult AddPatient()
        //  {
        //     return View();
        // }
        // public IActionResult NewPatientDetails(AddPatient pat)
        //{
        //     ClinicDAL obj = new ClinicDAL();
        //     int result = obj.NewPatientdetails(pat);
        //     if (result == 1)
        //          return RedirectToAction("Index");
        //     else
        //          return View("AddPatient");

        //   }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
