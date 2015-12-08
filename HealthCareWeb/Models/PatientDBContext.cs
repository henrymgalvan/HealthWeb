using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HealthCareWeb.Models
{
    public class PatientDBContext : DbContext
    {
        //DbSet<Patient> Patients { get; set; }

        public System.Data.Entity.DbSet<HealthCareWeb.Models.Patient> Patients { get; set; }
        public System.Data.Entity.DbSet<HealthCareWeb.Models.Appointment> Appointments { get; set; }
    }
}
