using BookingDoctorsAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingDoctorsAppointment.ViewModels
{
    public class EmployeeHomePageViewModel
    { 
        public int Id { get; set; }
        //public string Country { get; set; }
        public string Location { get; set; }
        public string Specialization { get; set; }
        public Doctor Doctor { get; set; }
    }
}