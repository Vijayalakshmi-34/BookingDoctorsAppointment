namespace BookingDoctorsAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "LocationId", "dbo.Locations");
            DropIndex("dbo.Employees", new[] { "LocationId" });
            DropColumn("dbo.Employees", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "LocationId");
            AddForeignKey("dbo.Employees", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
        }
    }
}
