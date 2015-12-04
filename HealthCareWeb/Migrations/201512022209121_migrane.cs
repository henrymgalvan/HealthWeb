namespace HealthCareWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrane : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        hospitalID = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        prefix = c.String(),
                        dob = c.String(),
                        age = c.String(),
                        phone = c.String(),
                        address = c.String(),
                        email = c.String(),
                        gender = c.String(),
                        maritalStatus = c.String(),
                        language = c.String(),
                        religion = c.String(),
                        PrimaryDoctor = c.String(),
                        emergencyContact = c.String(),
                    })
                .PrimaryKey(t => t.hospitalID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
        }
    }
}
