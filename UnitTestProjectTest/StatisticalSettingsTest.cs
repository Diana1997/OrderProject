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
    public class StatisticalSettingsTest
    {
        [TestMethod]
        public void StatisticalSettingsTest1()
        {
            StatisticalSettings  statisticalSettings;
            int id;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new StatisticalSettingsController(db);
                statisticalSettings = new StatisticalSettings
                {
                    AnagenAll = 1,
                    TelogenAll = 1,
                    AnagenTerm = 1,
                    TelogenTerm = 1,
                    AnagenVallus = 1,
                    TelogenVallus = 1,
                };

                id = ctrl.Create(statisticalSettings);
                var statisticalSettingsRes = ctrl.Get(id);
                Assert.IsNotNull(statisticalSettingsRes);
                Assert.AreEqual(1, statisticalSettingsRes.AnagenAll);
                Assert.AreEqual(1, statisticalSettingsRes.AnagenVallus);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new StatisticalSettingsController(db);
                statisticalSettings = new StatisticalSettings
                {
                    StatisticalSettingsID = id,
                    AnagenAll = 2,
                    TelogenAll = 1,
                    AnagenTerm = 1,
                    TelogenTerm = 1,
                    AnagenVallus = 1,
                    TelogenVallus = 1,
                };
                ctrl.Edit(statisticalSettings);
                var statisticalSettingsRes = ctrl.Get(id);
                Assert.IsNotNull(statisticalSettingsRes);
                Assert.AreEqual(2, statisticalSettingsRes.AnagenAll);
                Assert.AreEqual(1, statisticalSettingsRes.AnagenVallus);
            }
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new StatisticalSettingsController(db);
                ctrl.Delete(statisticalSettings.StatisticalSettingsID);
                var statisticalSettingsRes = ctrl.Get(id);
                Assert.IsNull(statisticalSettingsRes);
            }
        }
    }
}
