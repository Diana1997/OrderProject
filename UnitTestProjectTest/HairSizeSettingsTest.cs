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
    public class HairSizeSettingsTest
    {
        [TestMethod]
        public void HairSizeSettingsTest1()
        {
            HairSizeSettings  hairSizeSettings;
            int id;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new HairSizeSettingsController(db);
                hairSizeSettings = new HairSizeSettings
                {
                    DiameterOfTerminalsMediumThick = 1,
                    DiameterOfTerminalsThinMedium = 1,
                    DiameterOfVelusTerminal = 1,
                    LengthOfTelogenHair = 1,
                    RadiusOfFollicularUnits = 1,

                };

                id = ctrl.Create(hairSizeSettings);
                var hairSizeSettingsRes = ctrl.Get(id);
                Assert.IsNotNull(hairSizeSettingsRes);
                Assert.AreEqual(1, hairSizeSettingsRes.DiameterOfTerminalsMediumThick);
                Assert.AreEqual(1, hairSizeSettingsRes.DiameterOfTerminalsThinMedium);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new HairSizeSettingsController(db);
                hairSizeSettings = new HairSizeSettings
                {
                    HairSizeSettingsID = id,
                    DiameterOfTerminalsMediumThick = 2,
                    DiameterOfTerminalsThinMedium = 2,
                    DiameterOfVelusTerminal = 1,
                    LengthOfTelogenHair = 1,
                    RadiusOfFollicularUnits = 1,

                };
                ctrl.Edit(hairSizeSettings);
                var hairSizeSettingsRes = ctrl.Get(id);
                Assert.IsNotNull(hairSizeSettingsRes);
                Assert.AreEqual(2, hairSizeSettingsRes.DiameterOfTerminalsMediumThick);
                Assert.AreEqual(2, hairSizeSettingsRes.DiameterOfTerminalsThinMedium);
            }
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new HairSizeSettingsController(db);
                ctrl.Delete(hairSizeSettings.HairSizeSettingsID);
                var hairSizeSettingsRes = ctrl.Get(id);
                Assert.IsNull(hairSizeSettingsRes);
            }
        }
    }
}
