using BookingDoctorsAppointment.Interfaces;
using BookingDoctorsAppointment.Models;
using BookingDoctorsAppointment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingDoctorsAppointment.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private ApplicationDbContext dbContext = null;
        public HomeRepository()
        {
            dbContext = new ApplicationDbContext();
        }
        
        public Doctor GetDoctor(DoctorLoginViewModel LoginFromViewModel)
        {
            var doc= dbContext.Doctors.FirstOrDefault(e => e.EmailId == LoginFromViewModel.UserId || e.DoctorId.ToString() == LoginFromViewModel.UserId);
            return doc;
        }

        public Employee GetEmployee(EmployeeLoginViewModel LoginFromViewModel)
        {
            var emp = dbContext.Employees.FirstOrDefault(e => e.EmailId == LoginFromViewModel.UserId || e.SapId.ToString() == LoginFromViewModel.UserId);
            return emp;
        }
    }
}