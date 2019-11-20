namespace BookingDoctorsAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatSpecializationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Speciality = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Specializations");
        }
    }
}
