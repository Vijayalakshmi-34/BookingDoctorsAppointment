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
        public List<Doctor> GetDoctorsList(DoctorsListViewModel DoctorsFromView)
        {
            List<Doctor> doctors = dbContext.Doctors.Where(d => d.Location == DoctorsFromView.Location && d.Specialization == DoctorsFromView.Specialization).ToList();
            return doctors;
        }
    }
}