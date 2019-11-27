using BookingDoctorsAppointment.Models;
using BookingDoctorsAppointment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDoctorsAppointment.Interfaces
{
    public interface IHomeRepository
    {
        Employee GetEmployee(EmployeeLoginViewModel LoginFromViewModel);
        Doctor GetDoctor(DoctorLoginViewModel LoginFromViewModel);
    }
}
