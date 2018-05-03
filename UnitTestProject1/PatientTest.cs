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
        [TestMethod]
        public void CreatePatient()
        {
            new PatientsController().Create(
                new Patient
                {
                    CardNumber = 1,
                    ContactID = 1,
                    PatientStatus = PatientStatus.InTheService,
                    CreationDate = DateTime.Now,
                    ImageID = 1,
                    DateTimeNextVisit = DateTime.Now,
                }
                );
        }
        [TestMethod]
        public void EditPatient()
        {
            new PatientsController().Create(
                new Patient
                {
                    PatientID = 1,
                    CardNumber = 1,
                    ContactID = 1,
                    PatientStatus = PatientStatus.InTheService,
                    CreationDate = DateTime.Now,
                    ImageID = 1,
                    DateTimeNextVisit = DateTime.Now,
                }
            );
        }
        [TestMethod]
        public void GetByIdPatient()
        {
            new PatientsController().Get(1);
        }
        [TestMethod]
        public void GetPatient()
        {
            new PatientsController().Get();
        }
        [TestMethod]
        public void DeletePatient(int id)
        {
            new PatientsController().Delete(1);
        }

    }
}
