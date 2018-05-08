using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProject.Controller;
using OrderProject.Model;

namespace UnitTestProjectTest
{
    [TestClass]
    public class VisitTest
    {
        [TestMethod]
        public void VisitTest1()
        {
            Visit visit;
            int id;
            int userId;
            int researchId;
            int patientId;

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
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new UsersController(db);
                var user = new User
                {
                    Login = "l",
                    Password = new byte[1] { 0 },
                    ContactID = contactId,
                    LastLoginTime = DateTime.Now,
                };

                userId = ctrl.Create(user);
                var userRes = ctrl.Get(userId);
                Assert.IsNotNull(userRes);
            }

            // creation
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new PatientsController(db);

                var newPatient = new Patient
                {
                    CardNumber = 777,
                    ContactID = contactId,
                    PatientStatus = PatientStatus.InTheService,
                    CreationDate = DateTime.Now,
                    DateTimeNextVisit = DateTime.Now,
                };


                patientId = ctrl.Create(newPatient);

                var patient = ctrl.Get(patientId);

                Assert.IsNotNull(patient);
            }

            int imageId;
            int hairId;
            int settingId;
            int lensid;

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new ImagesController(db);
                var image = new Image()
                {
                    DateTime = DateTime.Now,
                    Title = "title",
                    ImageContent = new byte[2] { 0, 1 },
                };

                imageId = ctrl.Create(image);
                var imageRes = ctrl.Get(imageId);
                Assert.IsNotNull(imageRes);
            }
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new HairController(db);
                var hair = new Hair()
                {
                    Width = 1,
                    X1 = 1,
                    X2 = 1,
                    Y1 = 1,
                    Y2 = 1,
                };

                hairId = ctrl.Create(hair);
                var hairRes = ctrl.Get(hairId);
                Assert.IsNotNull(hair);
            }
            int hairSizeSettingsID;
            int statisticalSettingsID;

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new StatisticalSettingsController(db);
                var statisticalSettings = new StatisticalSettings
                {
                    AnagenAll = 1,
                    TelogenAll = 1,
                    AnagenTerm = 1,
                    TelogenTerm = 1,
                    AnagenVallus = 1,
                    TelogenVallus = 1,
                };

                statisticalSettingsID = ctrl.Create(statisticalSettings);
                var statisticalSettingsRes = ctrl.Get(statisticalSettingsID);
                Assert.IsNotNull(statisticalSettingsRes);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new HairSizeSettingsController(db);
                var hairSizeSettings = new HairSizeSettings
                {
                    DiameterOfTerminalsMediumThick = 1,
                    DiameterOfTerminalsThinMedium = 1,
                    DiameterOfVelusTerminal = 1,
                    LengthOfTelogenHair = 1,
                    RadiusOfFollicularUnits = 1,

                };

                hairSizeSettingsID = ctrl.Create(hairSizeSettings);
                var hairSizeSettingsRes = ctrl.Get(hairSizeSettingsID);
                Assert.IsNotNull(hairSizeSettingsRes);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new SettingsController(db);
                var setting = new Setting
                {
                    HairSizeSettingsID = hairSizeSettingsID,
                    StatisticalSettingsID = statisticalSettingsID,
                };

                settingId = ctrl.Create(setting);
                var settingsRes = ctrl.Get(settingId);
                Assert.IsNotNull(settingsRes);
            }
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new LensesController(db);
                var lens = new Lens()
                {
                    Name = "name",
                    Scale = 1
                };

                lensid = ctrl.Create(lens);
                var lensRes = ctrl.Get(lensid);
                Assert.IsNotNull(lensRes);
                Assert.AreEqual("name", lensRes.Name);
                Assert.AreEqual(1, lensRes.Scale);
            }
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new ResearchesController(db);
                var research = new Research()
                {
                    ResearchType = ResearchType.Phototrichogram,
                    StateOfTheResearch = StateOfTheResearch.Completed,
                    Thumbnail = new byte[1] { 0 },
                    ImageID = imageId,
                    HairID = hairId,
                    ResearchArea = 1,
                    SettingID = settingId,
                    LensID = lensid,
                    ResearchTime = DateTime.Now,
                };

                researchId = ctrl.Create(research);
                var researchRes = ctrl.Get(researchId);
                Assert.IsNotNull(researchRes);
            }
                using (var db = new ApplicationDbContext())
            {
                var ctrl = new VisitsController(db);
                visit = new Visit()
                {
                    UserID = userId,
                    PatientID = patientId,
                    DateTime = DateTime.Now,
                    ResearchID = researchId,
                };

                id = ctrl.Create(visit);
                var visitRes = ctrl.Get(id);
                Assert.IsNotNull(visitRes);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new VisitsController(db);
                visit = new Visit()
                {
                    VisitID = id,
                    UserID = userId,
                    PatientID = patientId,
                    DateTime = DateTime.Now,
                    ResearchID = researchId,
                };

                ctrl.Edit(visit);
                var visitRes = ctrl.Get(id);
                Assert.IsNotNull(visitRes);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new VisitsController(db);

                ctrl.Delete(visit.VisitID);

                // check results
                var visitRes = ctrl.Get(id);

                Assert.IsNull(visitRes);
            }
        }
    }
}
