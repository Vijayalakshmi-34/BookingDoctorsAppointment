namespace BookingDoctorsAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEmployeeTable : DbMigration
    {
        public override void Up()
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
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "LocationId", "dbo.Locations");
            DropIndex("dbo.Employees", new[] { "LocationId" });
            DropTable("dbo.Employees");
        }
    }
}
