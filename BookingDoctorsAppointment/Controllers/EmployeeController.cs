using BookingDoctorsAppointment.Models;
using BookingDoctorsAppointment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BookingDoctorsAppointment.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public EmployeeController()
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
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Location = ListCity();
            ViewBag.Specialization = ListSpecialization();
            return View();
        }
        [HttpPost]
        public ActionResult Index(EmployeeHomePageViewModel EmployeeFromView)
        {
            var doctors = dbContext.Doctors.Where(d => d.Location == EmployeeFromView.Location && d.Specialization == EmployeeFromView.Specialization).ToList();
            if (doctors.Count!=0)
            {
                return View("DisplayDoctors", doctors);
            }
            else
            {
                return Content("Doctors not found");
            }
        }
        public ActionResult Doctors()
        { 
            return View();
        }
        [NonAction]
        public IEnumerable<SelectListItem> ListCity()
        {
            var Location = (from l in dbContext.Doctors.AsEnumerable().GroupBy(l=>l.Location)
                            select new SelectListItem
                            {
                                Text=l.Key
                            }).ToList();

            Location.Insert(0, new SelectListItem { Text = "--Select Healthcare Location--", Value = "0", Disabled = true, Selected = true });

            return Location;
        }
        [NonAction]
        public IEnumerable<SelectListItem> ListSpecialization()
        {
            var Specialization = (from s in dbContext.Doctors.AsEnumerable().GroupBy(s=>s.Specialization)
                        select new SelectListItem
                        {
                            Text = s.Key
                        }).ToList();

            Specialization.Insert(0, new SelectListItem { Text = "--Select Specialization--", Value = "0", Disabled = true, Selected = true });

            return Specialization;
        }
    }
}