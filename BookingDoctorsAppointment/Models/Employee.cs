using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingDoctorsAppointment.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public long SapId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BloodGroup { get; set; }
        public string EmailId { get; set; }
        public long? MobileNumber { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Password { get; set; }
        public string InsuranceCardNumber { get; set; }

        public Location Locations { get; set; }
        public int LocationId { get; set; }
    }
}