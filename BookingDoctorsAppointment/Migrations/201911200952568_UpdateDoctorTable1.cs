namespace BookingDoctorsAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDoctorTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Location", c => c.String());
            AddColumn("dbo.Doctors", "Specialization", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Specialization");
            DropColumn("dbo.Doctors", "Location");
        }
    }
}
