using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingDoctorsAppointment.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public long DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }
        public byte? Experience { get; set; }
        public string Specialization { get; set; } 
        public long? MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string PassWord { get; set; }
        public bool? IsAvailable { get; set; }
        public Location Locations { get; set; }
        public int LocationId { get; set; }
    }
}