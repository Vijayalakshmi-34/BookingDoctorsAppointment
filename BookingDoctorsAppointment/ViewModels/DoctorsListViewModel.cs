using BookingDoctorsAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingDoctorsAppointment.ViewModels
{
    public class DoctorsListViewModel
    { 
        public int Id { get; set; }        
        public string Location { get; set; }
        public string Specialization { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
    }
}