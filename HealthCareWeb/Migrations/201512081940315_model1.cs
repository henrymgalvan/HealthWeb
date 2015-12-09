namespace HealthCareWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "patientID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "patientID");
        }
    }
}
