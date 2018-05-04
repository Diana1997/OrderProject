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

            // creation
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new PatientsController(db);

                newPatient = new Patient
                {
                    CardNumber = 777,
                    ContactID = 1,
                    PatientStatus = PatientStatus.InTheService,
                    CreationDate = DateTime.Now,
                    ImageID = 1,
                    DateTimeNextVisit = DateTime.Now,
                    //Contact = new Contact { Firstname = "Test" }
                };

               // newPatient.Visits.Add(new Visit { Comment = "comment" });

                id = ctrl.Create(newPatient);

                // test results
                var patient = ctrl.Get(id);

                Assert.IsNotNull(patient);
                Assert.AreEqual(777, patient.CardNumber);
                Assert.AreEqual("Test", patient.Contact.Firstname);
                // check that no visit is loadedd (leasy loading)
                Assert.AreEqual(0, patient.Visits.Count);
            }

            // modifying
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new PatientsController(db);

                newPatient.PatientID = id;
                newPatient.ImageID = 2;
                newPatient.Contact.Firstname = "Test2";
                ctrl.Edit(newPatient);

                // check results
                var patient = ctrl.Get(id);

                Assert.IsNotNull(patient);
                Assert.AreEqual(777, patient.CardNumber);
                Assert.AreEqual(2, patient.ImageID);
                Assert.AreEqual("Test2", patient.Contact.Firstname);
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
