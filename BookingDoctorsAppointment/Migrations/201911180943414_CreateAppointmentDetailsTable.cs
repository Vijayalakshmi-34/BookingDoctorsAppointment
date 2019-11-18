namespace BookingDoctorsAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAppointmentDetailsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointmentDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentNumber = c.Long(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        StatusOfBooking = c.String(),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .Index(t => t.EmployeeId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppointmentDetails", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.AppointmentDetails", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.AppointmentDetails", new[] { "DoctorId" });
            DropIndex("dbo.AppointmentDetails", new[] { "EmployeeId" });
            DropTable("dbo.AppointmentDetails");
        }
    }
}
