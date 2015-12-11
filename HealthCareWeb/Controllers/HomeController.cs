using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HealthCareWeb;
using HealthCareWeb.Models;
using System.Net;


namespace HealthCareWeb.Controllers
{
    public class HomeController : Controller
    {
        private PatientDBContext db = new PatientDBContext();
        AppointmentChecker appChecker = new AppointmentChecker();
        AlertChecker alert = new AlertChecker();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Information.";

            return View();
        }

        public ActionResult MyAppointments()
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Patient patient = db.Patients.Find(id);
            //if (patient == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(patient);
            if (db.Appointments.ToList().Count == 0)
            {
                return RedirectToAction("MyAppointmentsDefault");
            }
            return View(db.Appointments.ToList());
        }

        public ActionResult MyAppointmentsDefault()
        {
            return View();
        }

        // GET
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
            return View();
        }

        // GET
        public ActionResult CreateApp(int id)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
            Appointment app = new Appointment();
            Patient patient = db.Patients.Find(id);
            app.PatientName = patient.firstName + " " + patient.lastName;
            app.patientID = id;
            return View(app);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateApp([Bind(Include = "PatientName, DoctorName, UserId, Time, description, AppointID, patientID")] Appointment appointment)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
            if (ModelState.IsValid && appChecker.CheckAgainstAll(appointment))
            {
                //if(appointment.patientID != null)
                //{
                //    Patient patient = db.Patients.Find(appointment.patientID);
                //    patient.AppointmentId = appointment.AppointID;
                //}
                appointment.UserId = User.Identity.Name;
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("MyAppointments");
            }

            return View(appointment);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientName, DoctorName, UserId, Time, description, AppointID")] Appointment appointment)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
            if (ModelState.IsValid && appChecker.CheckAgainstAll(appointment))
            {
                
                appointment.UserId = User.Identity.Name;
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("MyAppointments");
            }

            return View(appointment);
        }

        public ActionResult Details(int? id)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment app = db.Appointments.Find(id);
            if (app == null)
            {
                return HttpNotFound();
            }
            return View(app);
        }
        public ActionResult EditApp(int? id)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment app = db.Appointments.Find(id);
            if (app == null)
            {
                return HttpNotFound();
            }
            return View(app);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditApp([Bind(Include = "PatientName, DoctorName, UserId, Time, description, AppointID")] Appointment appointment)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        public ActionResult Alerts()
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
            alert.checkApp();
            alert.checkPatients();
            ViewBag.appAlerts = alert.appointmentsAlerts.Count();
            ViewBag.patientAlerts = alert.patientsAlerts.Count();
            return View();
        }

        public ActionResult PatientAlerts()
        {
            //alert.checkPatients();
            //List<Patient> patients = new List<Patient>();
            //for (int i = 0; i < alert.patientsAlerts.Count; i++)
            //{
            //    Patient patient = db.Patients.Find(alert.patientsAlerts[i].ID);
            //    patients.Add(patient);
            //}
            //return View(patients);
            alert.checkPatients();
            List<Alert> alerts = new List<Alert>();
            for (int i = 0; i < alert.patientsAlerts.Count; i++)
            {
                Alert al = alert.patientsAlerts[i];
                alerts.Add(al);
            }
            return View(alerts);
        }
        public ActionResult AppAlerts()
        {
            alert.checkApp();
            //List<Appointment> apps = new List<Appointment>();
            //for (int i = 0; i < alert.appointmentsAlerts.Count; i++)
            //{
            //    Appointment app = db.Appointments.Find(alert.appointmentsAlerts[i].ID);
            //    apps.Add(app);
            //}
            //return View(apps);
            List<Alert> alerts = new List<Alert>();
            for (int i = 0; i < alert.appointmentsAlerts.Count; i++)
            {
                Alert al = alert.appointmentsAlerts[i];
                alerts.Add(al);
            }
            return View(alerts);
        }

        public ActionResult Edit(int? ID)
        {
            return RedirectToAction("Edit", "Patients", new { id = ID});
        }

        public ActionResult DetailsPatient(int? ID)
        {
            return RedirectToAction("Details", "Patients", new { id = ID});
        }

        public ActionResult Delete(int? ID)
        {
            return RedirectToAction("Delete", "Patients", new { id = ID });
        }
    }
}