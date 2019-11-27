using BookingDoctorsAppointment.Interfaces;
using BookingDoctorsAppointment.Models;
using BookingDoctorsAppointment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingDoctorsAppointment.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ApplicationDbContext dbContext = null;
        public EmployeeRepository()
        {
            dbContext = new ApplicationDbContext();
        }
        public List<Doctor> GetDoctorsList(EmployeeHomePageViewModel EmployeeFromView)
        {
            List<Doctor> doctors = dbContext.Doctors.Where(d => d.Location == EmployeeFromView.Location && d.Specialization == EmployeeFromView.Specialization).ToList();
            return doctors;
        }
    }
}