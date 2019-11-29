using BookingDoctorsAppointment.Models;
using BookingDoctorsAppointment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDoctorsAppointment.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Doctor> GetDoctorsList(DoctorsListViewModel EmployeeFromView);
    }
}
