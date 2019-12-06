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
    public class EmployeeController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public EmployeeController()
        {
            dbContext = new ApplicationDbContext();
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
        public ActionResult EmployeeLogin(ViewModel_Login loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var employee = dbContext.Employees.FirstOrDefault(e => e.EmailId == loginViewModel.UserId || e.SapId.ToString() == loginViewModel.UserId);
                if (employee == null)
                {
                    loginViewModel.LoginErrorMessage = "Invalid Sap Id or Mail Id";
                    return View("EmployeeLogin", loginViewModel);
                }
                else if (employee.Password == loginViewModel.Password)
                {
                    Session["employee"] = employee;
                    Session["employeeId"] = employee.Id;
                    return RedirectToAction("Index");
                }
                else
                {
                    loginViewModel.LoginErrorMessage = "Incorrect Password....Try again!!!!";
                    return View("EmployeeLogin", loginViewModel);
                }
            }
        }
        public ActionResult MyDetails()
        {
            ViewBag.employee = Session["employee"];
            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var employee = dbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            var empInDb = dbContext.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (empInDb != null)
            {
                empInDb.EmployeeFirstName = employee.EmployeeFirstName;
                empInDb.EmployeeLastName = employee.EmployeeLastName;
                empInDb.EmailId = employee.EmailId;
                empInDb.Password = employee.Password;
                empInDb.MobileNumber = employee.MobileNumber;
                empInDb.DateOfBirth = employee.DateOfBirth;
                empInDb.BloodGroup = employee.BloodGroup;
                empInDb.Location = employee.Location;
                empInDb.Location = employee.Location;
            }

            dbContext.SaveChanges();
            //Session["employee"] = empInDb;
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult BookAppointment()
        {
            ViewBag.Location = ListCity();
            ViewBag.Specialization = ListSpecialization();
            return View();
        }
        [HttpPost]
        public ActionResult BookAppointment(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Location = ListCity();
                ViewBag.Specialization = ListSpecialization();
                return View();
            }
            var doctors = dbContext.Doctors.Where(d => d.Location == doctor.Location && d.Specialization == doctor.Specialization && d.IsAvailable == true).ToList();
            if (doctors.Count != 0)
            {
                return View("DisplayDoctors", doctors);
            }
            else
            {
                return Content("Doctors not found");
            }
        }
        [HttpPost]
        public ActionResult SearchByDoctorName(string search)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Location = ListCity();
                ViewBag.Specialization = ListSpecialization();
                return View();
            }
            var doctor = dbContext.Doctors.Where(d => (d.DoctorFirstName.Contains(search) || d.DoctorLastName.Contains(search)) && d.IsAvailable == true).ToList();
            if (doctor.Count != 0)
            {
                return View("DisplayDoctors", doctor);
            }
            else
            {
                return Content("Doctors not found");
            }
        }
        public ActionResult DisplayDoctors(Doctor doctor)
        {

            return View(doctor);
        }
        [HttpGet]
        public ActionResult TimeSlots(int id)
        {
            Session["doctorId"] = id;
            var appointment = new AppointmentDetails();
            ViewBag.TimeSlotsId = ListTimeSlot();
            return View(appointment);
        }
        [HttpPost]
        public ActionResult TimeSlots(AppointmentDetails appointment)
        {
            var details = dbContext.AppointmentDetails.Where(a => a.AppointmentDate == appointment.AppointmentDate).ToList();
            Random random = new Random();
            appointment.AppointmentNumber = random.Next(1000, 9000);
            appointment.StatusOfBooking = "Booked";
            appointment.EmployeeId = (int)Session["employeeId"];
            appointment.DoctorId = (int)Session["doctorId"];
            if (details.Count != 0)
            {
                var record = details.Where(a => a.TimeSlotsId == appointment.TimeSlotsId).ToList();
                if (record.Count != 0)
                {
                    var patient = record.Where(p => p.EmployeeId == appointment.EmployeeId && p.DoctorId == appointment.DoctorId).ToList();
                    if (patient.Count != 0)
                    {
                        return Content("This slot was already booked");
                    }
                }
            }
                dbContext.AppointmentDetails.Add(appointment);
                dbContext.SaveChanges();
            return RedirectToAction("Confirmation");         
        }
        public ActionResult Confirmation()
        {
            return View();
        }
        public ActionResult CancelAppointment(int id)
        {
            var patients = dbContext.AppointmentDetails.Find(id);
            dbContext.AppointmentDetails.Remove(patients);
            dbContext.SaveChanges();
            return View();
        }
        public ActionResult BookingDetails()
        {
            int id = (int)Session["employeeId"];
            var details = dbContext.AppointmentDetails.Include(a => a.TimeSlots).Include(a => a.Employee).Include(a => a.Doctor).Where(a=>a.EmployeeId==id).ToList();
            return View(details);
        }
        [NonAction]
        public IEnumerable<SelectListItem> ListCity()
        {
            var Location = (from l in dbContext.Doctors.AsEnumerable().GroupBy(l => l.Location)
                            select new SelectListItem
                            {
                                Text = l.Key
                            }).ToList();

            Location.Insert(0, new SelectListItem { Text = "--Select Healthcare Location--", Value = "0", Disabled = true, Selected = true });

            return Location;
        }
        [NonAction]
        public IEnumerable<SelectListItem> ListSpecialization()
        {
            var Specialization = (from s in dbContext.Doctors.AsEnumerable().GroupBy(s => s.Specialization)
                                  select new SelectListItem
                                  {
                                      Text = s.Key
                                  }).ToList();

            Specialization.Insert(0, new SelectListItem { Text = "--Select Specialization--", Value = "0", Disabled = true, Selected = true });

            return Specialization;

        }
        [NonAction]
        public IEnumerable<SelectListItem> ListTimeSlot()
        {
            var TimeSlot = (from m in dbContext.TimeSlots.AsEnumerable()
                            select new SelectListItem
                            {
                                Text = m.TimeSlot,
                                Value = m.Id.ToString()
                            }).ToList();

            TimeSlot.Insert(0, new SelectListItem { Text = "---Select---", Value = "0", Disabled = true, Selected = true });

            return TimeSlot;
        }
        
    }
}