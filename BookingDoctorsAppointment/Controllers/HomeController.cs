using BookingDoctorsAppointment.Interfaces;
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
        IHomeRepository repository = null;
        public HomeController()
        {

        }
        public HomeController(IHomeRepository Repository)
        {
            repository = Repository;
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
            var emp = repository.GetEmployee(LoginFromViewModel);
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
            var doc = repository.GetDoctor(LoginFromViewModel);
            if (doc == null)
            {
                return Content("Invalid Doctor Id or Mail Id");
            }
            else if (doc.PassWord == LoginFromViewModel.PassWord)
            {
                return RedirectToAction("Index", "Doctor");
            }

            return Content("Incorrect Password....Try again!!!!");
        }
    }
}