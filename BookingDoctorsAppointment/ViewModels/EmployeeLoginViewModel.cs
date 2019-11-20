using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingDoctorsAppointment.ViewModels
{
    public class EmployeeLoginViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Sap Id / Email Id")]
        public string UserId { get; set; }

        [Required,StringLength(10,ErrorMessage ="Password should be 5 to 10 characters",MinimumLength =5)]
        [Display(Name ="Password")]
        public string Password { get; set; }
    }
}