namespace BookingDoctorsAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dummy1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "SpecializationId");
        }
        
        public override void Down()
        {
        }
    }
}
