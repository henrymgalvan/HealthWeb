namespace HealthCareWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "patientID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "patientID", c => c.Int(nullable: false));
        }
    }
}
