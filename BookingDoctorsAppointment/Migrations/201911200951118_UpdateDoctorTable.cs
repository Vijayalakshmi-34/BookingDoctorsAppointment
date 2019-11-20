namespace BookingDoctorsAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDoctorTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Doctors", "SpecializationId", "dbo.Specializations");
            DropIndex("dbo.Doctors", new[] { "LocationId" });
            DropIndex("dbo.Doctors", new[] { "SpecializationId" });
            DropColumn("dbo.Doctors", "LocationId");
            DropColumn("dbo.Doctors", "SpecializationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "SpecializationId", c => c.Int(nullable: false));
            AddColumn("dbo.Doctors", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "SpecializationId");
            CreateIndex("dbo.Doctors", "LocationId");
            AddForeignKey("dbo.Doctors", "SpecializationId", "dbo.Specializations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Doctors", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
        }
    }
}
