namespace OnlineDoctorsAppointmentBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropcolumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AppointmentDetails", "AppointmentTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppointmentDetails", "AppointmentTime", c => c.String());
        }
    }
}
