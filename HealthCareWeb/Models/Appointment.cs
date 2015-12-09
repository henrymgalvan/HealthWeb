using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;


namespace HealthCareWeb.Models
{
    public class Appointment
    {
        public string PatientName { get; set; }

        public string DoctorName { get; set; }

        public string UserId { get; set; }

        //public string Month { get; set; }

        //public string year { get; set; }

        //public string day { get; set; }

        //public string hour { get; set; }

        public DateTime? Time { get; set; }
        public string description { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointID { get; set; }

        public int patientID;


    }
}