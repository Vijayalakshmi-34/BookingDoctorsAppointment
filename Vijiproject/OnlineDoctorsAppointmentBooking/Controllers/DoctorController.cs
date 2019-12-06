using OnlineDoctorsAppointmentBooking.Models;
using OnlineDoctorsAppointmentBooking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace OnlineBookingDoctorsAppointment.Controllers
{
    public class DoctorController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public DoctorController()
        {
            dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public ActionResult DoctorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoctorLogin(ViewModel_Login loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    var doctor = dbContext.Doctors.FirstOrDefault(e => e.EmailId == loginViewModel.UserId || e.DoctorId.ToString() == loginViewModel.UserId);
                    if (doctor == null)
                    {
                        loginViewModel.LoginErrorMessage = "Invalid Sap Id or Mail Id";
                        return View("DoctorLogin", loginViewModel);
                    }
                    else if (doctor.PassWord == loginViewModel.Password)
                    {
                        Session["doctor"] = doctor;
                        Session["doctorId"] = doctor.Id;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        loginViewModel.LoginErrorMessage = "Incorrect Password....Try again!!!!";
                        return View("DoctorLogin", loginViewModel);
                    }
                }
            }
        }
        public ActionResult Index()
        {
            var doctor = (Doctor)Session["doctor"];
            return View(doctor);
        }
        public ActionResult MyAppointments()
        {
            int id = (int)Session["doctorId"];
            var appointments = dbContext.AppointmentDetails.Include(a=>a.Doctor).Include(a=>a.Employee).Include(a=>a.TimeSlots).Where(a => a.DoctorId == id).ToList();
            return View(appointments);
        }
       
    }
}