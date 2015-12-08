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
            ViewBag.Message = "Your contact page.";

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

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientName, DoctorName, UserId, Month, year, day, hour, description, AppointID")] Appointment appointment)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
             if (ModelState.IsValid)
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

    }
}