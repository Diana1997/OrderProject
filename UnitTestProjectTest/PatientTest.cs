using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProject.Controller;
using OrderProject.Model;


namespace UnitTestProject1
{
    [TestClass]
    public class PatientTest
    {
        [TestInitialize]
        public void Init()
        {
            // remove all Patients with cardNumber = 777
        }

        [TestMethod]
        public void PatientTest1()
        {
            int id;
            Patient newPatient;
            int contactId;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new ContactsController(db);
                var contact = new Contact
                {
                    Firstname = "f",
                    Secondname = "s",
                    Lastname = "l",
                    Gender = Gender.Femail,
                    Birthday = DateTime.Now,
                };

                contactId = ctrl.Create(contact);
                var contactRes = ctrl.Get(contactId);
                Assert.IsNotNull(contact);
            }
            // creation
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new PatientsController(db);

                newPatient = new Patient
                {
                    CardNumber = 777,
                    ContactID = contactId,
                    PatientStatus = PatientStatus.InTheService,
                    CreationDate = DateTime.Now,
                    DateTimeNextVisit = DateTime.Now,
                };


                id = ctrl.Create(newPatient);

                var patient = ctrl.Get(id);

                Assert.IsNotNull(patient);
                Assert.AreEqual(777, patient.CardNumber);
                Assert.AreEqual(0, patient.Visits.Count);
            }

            // modifying
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new PatientsController(db);

                newPatient = new Patient
                {
                    PatientID = id,
                    CardNumber = 777,
                    ContactID = contactId,
                    PatientStatus = PatientStatus.InTheService,
                    CreationDate = DateTime.Now,
                    DateTimeNextVisit = DateTime.Now,
                    //Contact = new Contact { Firstname = "Test" }
                };
                ctrl.Edit(newPatient);

                // check results
                var patient = ctrl.Get(id);

                Assert.IsNotNull(patient);
                Assert.AreEqual(777, patient.CardNumber);
            }

            // deleting
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new PatientsController(db);

                ctrl.Delete(newPatient.PatientID);

                // check results
                var patient = ctrl.Get(id);

                Assert.IsNull(patient);
            }

        }


    }
}
