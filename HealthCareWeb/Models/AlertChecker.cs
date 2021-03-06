﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCareWeb.Models
{
    public class AlertChecker
    {
        public PatientDBContext db = new PatientDBContext();
        public List<Alert> patientsAlerts = new List<Alert>();
        public List<Alert> appointmentsAlerts = new List<Alert>();

        public void checkPatients()
        {
            
            List<Patient> patient = db.Patients.ToList();
            for(int i = 0; i < patient.Count; i++)
            {
                Alert a = new Alert();
                a.ID = patient[i].hospitalID;
                a.name = patient[i].firstName + " " + patient[i].lastName;
                a.message = "Medical Record " + a.ID + " is missing the following content: ";  
                bool beginAlert = true;
                if(patient[i].firstName == null)
                {
                    beginAlert = false;
                    a.message += "First Name, ";  

                }
                if(patient[i].lastName == null)
                {
                    beginAlert = false;
                    a.message += "Last Name, ";  
                }
                if(patient[i].prefix == null)
                {
                    beginAlert = false;
                    a.message += "Prefix, ";  
                }
                if(patient[i].dob == null)
                {
                    beginAlert = false;
                    a.message += "Date Of Birth, ";  
                }
                if(patient[i].phone == null)
                {
                    beginAlert = false;
                    a.message += "Phone, ";  
                }
                if(patient[i].address == null)
                {
                    beginAlert = false;
                    a.message += "Address, ";  
                }
                if(patient[i].email == null)
                {
                    beginAlert = false;
                    a.message += "Email, ";  
                }
                if(patient[i].gender == null)
                {
                    beginAlert = false;
                    a.message += "Gender, ";  
                }
                if(patient[i].maritalStatus == null)
                {
                    beginAlert = false;
                    a.message += "Marital Status, ";  
                }
                if(patient[i].language == null)
                {
                    beginAlert = false;
                    a.message += "Language, ";  
                }
                if (patient[i].religion == null)
                {
                    beginAlert = false;
                    a.message += "Religion, ";  
                }
                if (patient[i].PrimaryDoctor == null)
                {
                    beginAlert = false;
                    a.message += "Primary Doctor, ";  
                }
                if (patient[i].emergencyContact == null)
                {
                    beginAlert = false;
                    a.message += "Emergency Contact, ";  
                }
                if (beginAlert == false)
                {
                    patientsAlerts.Add(a);
                }


            }
            
        }

        public void checkApp()
        {
            
            List<Appointment> App = db.Appointments.ToList();
            for (int i = 0; i < App.Count; i++)
            {
                Alert a = new Alert();
                a.ID = App[i].AppointID;
                a.name = App[i].PatientName;
                a.message = "Appointment " + a.ID + " is missing the following content: ";
                bool beginAlert = true;
                if (App[i].PatientName == null)
                {
                    beginAlert = false;
                    a.message += "Patient Name, ";

                }
                if (App[i].DoctorName  == null)
                {
                    beginAlert = false;
                    a.message += "Doctor Name, ";

                }
                if (App[i].Time == null)
                {
                    beginAlert = false;
                    a.message += "Time, ";

                }
                if (App[i].description  == null)
                {
                    beginAlert = false;
                    a.message += "Description, ";

                }
                if(beginAlert == false)
                {
                    appointmentsAlerts.Add(a);
                }
            }
        }
    
    }
}