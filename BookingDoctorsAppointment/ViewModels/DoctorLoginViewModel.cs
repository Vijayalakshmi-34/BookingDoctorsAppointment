using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingDoctorsAppointment.ViewModels
{
    public class DoctorLoginViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Doctor Id / Email Id")]
        public string UserId { get; set; }

        [Required, StringLength(12, ErrorMessage = "Password should be 5 to 10 characters", MinimumLength = 5)]
        [Display(Name ="Pass Word")]
        public string PassWord { get; set; }
    }
}