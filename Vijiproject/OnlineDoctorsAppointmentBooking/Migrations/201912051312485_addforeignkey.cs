namespace OnlineDoctorsAppointmentBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addforeignkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppointmentDetails", "TimeSlotsId", c => c.Int(nullable: false));
            CreateIndex("dbo.AppointmentDetails", "TimeSlotsId");
            AddForeignKey("dbo.AppointmentDetails", "TimeSlotsId", "dbo.TimeSlots", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppointmentDetails", "TimeSlotsId", "dbo.TimeSlots");
            DropIndex("dbo.AppointmentDetails", new[] { "TimeSlotsId" });
            DropColumn("dbo.AppointmentDetails", "TimeSlotsId");
        }
    }
}
