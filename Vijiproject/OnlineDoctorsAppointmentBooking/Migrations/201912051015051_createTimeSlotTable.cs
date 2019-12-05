namespace OnlineDoctorsAppointmentBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTimeSlotTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimeSlots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeSlot = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TimeSlots");
        }
    }
}
