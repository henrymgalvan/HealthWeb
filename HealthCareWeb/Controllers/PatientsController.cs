using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HealthCareWeb;
using HealthCareWeb.Models;

namespace HealthCareWeb.Controllers
{
    public class PatientsController : Controller
    {

   
        private PatientDBContext db = new PatientDBContext();
        AlertChecker alert = new AlertChecker();
        // GET: Patients
        //public ActionResult Index()
        //{
        //    return View(db.Patients.ToList());
        //}

        public ActionResult Index(string searchString)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }

            var nameSearch = from q in db.Patients
                                select q;


            if (!String.IsNullOrEmpty(searchString))
            {
                nameSearch = nameSearch.Where(f => (f.firstName.Contains(searchString) || f.lastName.Contains(searchString) || f.hospitalID.ToString().Contains(searchString)));
            }




            return View(nameSearch);
        }


        // GET: Patients/Details/5
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
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            alert.checkPatients();
            if(alert.patientsAlerts.Count > 0)
            {
                for (int i = 0; i < alert.patientsAlerts.Count; i++)
                {
                    if (alert.patientsAlerts[i].ID == id)
                    {
                        ViewBag.Alert = "Alert: !";
                        ViewBag.AlertMessage = "Record is missing content";
                    }
                }
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hospitalID,firstName,lastName,prefix,dob,age,phone,address,email,gender,maritalStatus,language,religion,PrimaryDoctor,emergencyContact")] Patient patient)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
            if (ModelState.IsValid)
            {
                SetAge(patient);
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hospitalID,firstName,lastName,prefix,dob,age,phone,address,email,gender,maritalStatus,language,religion,PrimaryDoctor,emergencyContact")] Patient patient)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
            if (ModelState.IsValid)
            {
                SetAge(patient);
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Print(int? id)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account", null);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        public ActionResult AddAppointment(int? id)
        {
            return RedirectToAction("CreateApp", "Home", new { ID = id });
        }

        public void SetAge(Patient patient)
        {
            double ApproxDaysPerYear = 365.25;
            DateTime birthday = new DateTime();
            DateTime.TryParse(patient.dob, out birthday);
            int days = (DateTime.Now.Subtract(birthday)).Days;
            int years = (int)(days / ApproxDaysPerYear);
            patient.age = years.ToString();
        }
    }
}
