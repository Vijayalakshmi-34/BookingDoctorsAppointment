using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineDoctorBookingAppointment.Startup))]
namespace OnlineDoctorBookingAppointment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
