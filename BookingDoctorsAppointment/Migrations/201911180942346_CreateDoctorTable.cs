namespace BookingDoctorsAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDoctorTable : DbMigration
    {
        public override void Up()
        {
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
                        Specialization = c.String(),
                        MobileNumber = c.Long(),
                        EmailId = c.String(),
                        PassWord = c.String(),
                        IsAvailable = c.Boolean(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "LocationId", "dbo.Locations");
            DropIndex("dbo.Doctors", new[] { "LocationId" });
            DropTable("dbo.Doctors");
        }
    }
}
