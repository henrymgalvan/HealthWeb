using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareWeb.Models
{
    public class Patient
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string prefix { get; set; }
        public string dob { get; set; }
        public string age { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string maritalStatus { get; set; }
        public string language { get; set; }
        public string religion { get; set; }
        public string PrimaryDoctor { get; set; }
        public string emergencyContact { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int hospitalID { get; set; }


        public Patient()
        {
            firstName = "";
            lastName = "";
            prefix = "";
            dob = "";
            age = "";
            phone = "";
            address = "";
            email = "";
            gender = "";
            maritalStatus = "";
            language = "";
            religion = "";
            PrimaryDoctor = "";
            emergencyContact = "";
        }
            
    }
}
