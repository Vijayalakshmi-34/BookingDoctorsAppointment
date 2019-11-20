using BookingDoctorsAppointment.Models;
using BookingDoctorsAppointment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingDoctorsAppointment.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public HomeController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EmployeeLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeLogin(EmployeeLoginViewModel LoginFromViewModel)
        {
            var emp = dbContext.Employees.FirstOrDefault(e => e.EmailId == LoginFromViewModel.UserId || e.SapId.ToString() == LoginFromViewModel.UserId);
            if(emp==null)
            {
                return Content("Invalid Sap Id or Mail Id");
            }
            else if (emp.Password == LoginFromViewModel.Password)
            {
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return Content("Incorrect Password....Try again!!!!");
            }
        }
        [HttpGet]
        public ActionResult DoctorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoctorLogin(DoctorLoginViewModel LoginFromViewModel)
        {
            var emp = dbContext.Doctors.FirstOrDefault(e => e.EmailId == LoginFromViewModel.UserId || e.DoctorId.ToString() == LoginFromViewModel.UserId);
            if (emp == null)
            {
                return Content("Invalid Doctor Id or Mail Id");
            }
            else if (emp.PassWord == LoginFromViewModel.PassWord)
            {
                return RedirectToAction("Index", "Doctor");
            }

            return Content("Incorrect Password....Try again!!!!");
        }
    }
}