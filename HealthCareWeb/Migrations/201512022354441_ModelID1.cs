namespace HealthCareWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelID1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patients", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "ID", c => c.Int(nullable: false));
        }
    }
}
