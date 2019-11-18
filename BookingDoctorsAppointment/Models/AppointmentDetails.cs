using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingDoctorsAppointment.Models
{
    public class AppointmentDetails
    {
        public int Id { get; set; }
        public long AppointmentNumber { get; set; }
        public Employee Employees { get; set; }
        public int EmployeeId { get; set; }
        public Doctor Doctors { get; set; }
        public int DoctorId { get; set; }
        public string StatusOfBooking { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

    }
}