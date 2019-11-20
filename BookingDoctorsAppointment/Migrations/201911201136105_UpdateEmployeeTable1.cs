namespace BookingDoctorsAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Location");
        }
    }
}
