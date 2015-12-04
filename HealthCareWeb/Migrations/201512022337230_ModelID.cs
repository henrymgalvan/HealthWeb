namespace HealthCareWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "ID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "ID");
        }
    }
}
