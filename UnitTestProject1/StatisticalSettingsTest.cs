using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProject.Controller;
using OrderProject.Model;

namespace UnitTestProject1
{
    [TestClass]
    public class StatisticalSettingsTest
    {
        [TestMethod]
        public void CreateStatisticalSettings()
        {
            new StatisticalSettingsController().Create(
                new StatisticalSettings
                {
                    AnagenAll = 1,
                    TelogenAll = 1,
                    AnagenTerm = 1,
                    TelogenTerm = 1,
                    AnagenVallus = 1,
                    TelogenVallus = 1,
                }
            );
        }
        [TestMethod]
        public void EditStatisticalSettings()
        {
            new StatisticalSettingsController().Edit(
               new StatisticalSettings
               {
                   StatisticalSettingsID = 2,
                   AnagenAll = 1,
                   TelogenAll = 2,
                   AnagenTerm = 2,
                   TelogenTerm = 2,
                   AnagenVallus = 1,
                   TelogenVallus = 1,
               }
           );
        }
        [TestMethod]
        public void GetStatisticalSettingsById()
        {
            new StatisticalSettingsController().Get(1);
        }
        [TestMethod]
        public void GetStatisticalSettings()
        {
            new StatisticalSettingsController().Get();
        }
        [TestMethod]
        public void DeleteStatisticalSettings()
        {
            new StatisticalSettingsController().Delete(1);
        }
    }
}
