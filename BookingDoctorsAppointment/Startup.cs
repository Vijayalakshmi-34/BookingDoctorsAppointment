using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookingDoctorsAppointment.Startup))]
namespace BookingDoctorsAppointment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
