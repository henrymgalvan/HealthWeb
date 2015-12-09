using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCareWeb.Models
{
    public class AppointmentChecker
    {
        PatientDBContext db = new PatientDBContext();

        //Checks to see if two times are within 15 minutes of each other false if conflict, true if no conflict
        public bool CheckTimeConflict(Appointment app1, Appointment app2)
        {
            if(app1.Time != null)
            {
                DateTime Time1 = new DateTime();
                Time1 = app1.Time.GetValueOrDefault(); 
                if(app2.Time != null)
                {
                    DateTime Time2 = new DateTime();
                    Time2 = app2.Time.GetValueOrDefault();
                    if (Time1.Year == Time2.Year)
                    {
                        if (Time1.Month == Time2.Month)
                        {
                            if (Time1.Day == Time2.Day)
                            {
                                if (Time1.Hour == Time2.Hour)
                                {
                                    if(Time1.Minute != Time2.Minute)
                                    {
                                        if (Time1.AddMinutes(-15) >= Time2 || Time2.AddMinutes(15) <= Time2)
                                        {
                                            return true;
                                        }
                                    }
                                    return false;
                                }                                
                            }
                        }
                    }
                }
            }
            return true;
        }

        //checks all appointments in database for time conflicts, returns false if conflict, true if no conflict
        public bool CheckAgainstAll(Appointment app)
        {
            List<Appointment> apps = db.Appointments.ToList();
            for(int i = 0; i < apps.Count; i++)
            {
                if(CheckDoctor(app, apps[i]) || CheckPatient(app,apps[i]))
                {
                    if(CheckTimeConflict(app, apps[i]) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckDoctor(Appointment app1, Appointment app2)
        {
            if(app1.DoctorName == app2.DoctorName)
            {
                return true;
            }
            return false;
        }

        public bool CheckPatient(Appointment app1, Appointment app2)
        {
            if(app1.PatientName == app2.PatientName)
            {
                return true;
            }
            return false;
        }
    }
}