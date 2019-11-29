namespace BookingDoctorsAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropcolumninDoctorTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Doctors", "FirstName");
            DropColumn("dbo.Doctors", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "LastName", c => c.String());
            AddColumn("dbo.Doctors", "FirstName", c => c.String());
        }
    }
}
