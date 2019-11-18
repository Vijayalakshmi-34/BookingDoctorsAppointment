namespace BookingDoctorsAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateLocationTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AppointmentDetails");
            DropTable("dbo.Doctors");
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SapId = c.Long(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BloodGroup = c.String(),
                        EmailId = c.String(),
                        MobileNumber = c.Long(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(),
                        Password = c.String(),
                        InsuranceCardNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Long(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Qualification = c.String(),
                        Experience = c.Byte(),
                        Speciality = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        MobileNumber = c.Long(),
                        EmailId = c.String(),
                        PassWord = c.String(),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppointmentDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentNumber = c.Long(nullable: false),
                        StatusOfBooking = c.String(),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
