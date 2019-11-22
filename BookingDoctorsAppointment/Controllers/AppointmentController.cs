using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingDoctorsAppointment.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment

        [HttpGet]
        public ActionResult Index(int id)
        {
            return View();
        }
    }
}