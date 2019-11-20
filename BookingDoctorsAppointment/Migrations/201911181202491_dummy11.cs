namespace BookingDoctorsAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dummy11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "SpecializationId", "dbo.Specializations");
        }
        
        public override void Down()
        {
        }
    }
}
