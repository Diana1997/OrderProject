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
    public class ResearchTest
    {
        [TestMethod]
        public void ResearchTest1()
        {
            Research research;
            int id;
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
                research = new Research()
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

                id = ctrl.Create(research);
                var researchRes = ctrl.Get(id);
                Assert.IsNotNull(researchRes);
                Assert.AreEqual(ResearchType.Phototrichogram, researchRes.ResearchType);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new ResearchesController(db);
                research = new Research()
                {
                    ResearchID = id,
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
                ctrl.Edit(research);

                id = ctrl.Create(research);
                var researchRes = ctrl.Get(id);
                Assert.IsNotNull(researchRes);
                Assert.AreEqual(ResearchType.Phototrichogram, researchRes.ResearchType);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new ResearchesController(db);

                ctrl.Delete(research.ResearchID);

                // check results
                var researchRes = ctrl.Get(id);
                Assert.IsNull(researchRes);
            }
        }
    }
}
