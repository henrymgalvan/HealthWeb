namespace HealthCareWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Time", c => c.DateTime(nullable: false));
            DropColumn("dbo.Appointments", "Month");
            DropColumn("dbo.Appointments", "year");
            DropColumn("dbo.Appointments", "day");
            DropColumn("dbo.Appointments", "hour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "hour", c => c.String());
            AddColumn("dbo.Appointments", "day", c => c.String());
            AddColumn("dbo.Appointments", "year", c => c.String());
            AddColumn("dbo.Appointments", "Month", c => c.String());
            DropColumn("dbo.Appointments", "Time");
        }
    }
}
