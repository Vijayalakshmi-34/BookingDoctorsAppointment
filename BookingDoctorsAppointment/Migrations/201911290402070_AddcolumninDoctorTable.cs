namespace BookingDoctorsAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcolumninDoctorTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "DoctorFirstName", c => c.String());
            AddColumn("dbo.Doctors", "DoctorLastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "DoctorLastName");
            DropColumn("dbo.Doctors", "DoctorFirstName");
        }
    }
}
