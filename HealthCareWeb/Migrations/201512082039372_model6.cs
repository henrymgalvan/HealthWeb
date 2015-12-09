namespace HealthCareWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "Time", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "Time", c => c.DateTime(nullable: false));
        }
    }
}
