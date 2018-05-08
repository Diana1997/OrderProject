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
    public class SettingsTest
    {
        [TestMethod]
        public void SettingsTest1()
        {
            Setting setting;
            int id;

            int hairSizeSettingsID;
            int statisticalSettingsID;

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new StatisticalSettingsController(db);
               var  statisticalSettings = new StatisticalSettings
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
                Assert.AreEqual(1, hairSizeSettingsRes.DiameterOfTerminalsMediumThick);
                Assert.AreEqual(1, hairSizeSettingsRes.DiameterOfTerminalsThinMedium);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new SettingsController(db);
                setting = new Setting
                {
                    HairSizeSettingsID = hairSizeSettingsID,
                    StatisticalSettingsID = statisticalSettingsID,
                };

                id = ctrl.Create(setting);
                var settingsRes = ctrl.Get(id);
                Assert.IsNotNull(settingsRes);
                Assert.AreEqual(hairSizeSettingsID, settingsRes.HairSizeSettingsID);
                Assert.AreEqual(statisticalSettingsID, settingsRes.StatisticalSettingsID);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new SettingsController(db);
                setting = new Setting
                {
                    SettingsID = id,
                    HairSizeSettingsID = hairSizeSettingsID,
                    StatisticalSettingsID = statisticalSettingsID,
                };

                ctrl.Edit(setting);
                var settingRes = ctrl.Get(id);
                Assert.IsNotNull(settingRes);
            }
            using (var db = new ApplicationDbContext())
            { 
                var ctrl = new SettingsController(db);
                ctrl.Delete(setting.SettingsID);
                var settingRes = ctrl.Get(id);
                Assert.IsNull(settingRes);
            }
        }
    }
}
