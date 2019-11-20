namespace BookingDoctorsAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppointmentDetails", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.AppointmentDetails", "DoctorId");
            AddForeignKey("dbo.AppointmentDetails", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppointmentDetails", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.AppointmentDetails", new[] { "DoctorId" });
            DropColumn("dbo.AppointmentDetails", "DoctorId");
        }
    }
}
