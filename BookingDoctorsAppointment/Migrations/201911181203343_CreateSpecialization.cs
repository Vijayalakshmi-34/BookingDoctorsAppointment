namespace BookingDoctorsAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSpecialization : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "SpecializationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "SpecializationId");
            AddForeignKey("dbo.Doctors", "SpecializationId", "dbo.Specializations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "SpecializationId", "dbo.Specializations");
            DropIndex("dbo.Doctors", new[] { "SpecializationId" });
            DropColumn("dbo.Doctors", "SpecializationId");
        }
    }
}
