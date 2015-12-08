namespace HealthCareWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "AppointmentId_AppointID", c => c.Int());
            CreateIndex("dbo.Patients", "AppointmentId_AppointID");
            AddForeignKey("dbo.Patients", "AppointmentId_AppointID", "dbo.Appointments", "AppointID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "AppointmentId_AppointID", "dbo.Appointments");
            DropIndex("dbo.Patients", new[] { "AppointmentId_AppointID" });
            DropColumn("dbo.Patients", "AppointmentId_AppointID");
        }
    }
}
