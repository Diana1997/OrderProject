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
    public class HairSizeSettingTest
    {
        [TestMethod]
        public void CreateHairSizeSetting()
        {
            new HairSizeSettingsController().Create(
                new HairSizeSettings
                {
                    DiameterOfTerminalsMediumThick = 1,
                    DiameterOfTerminalsThinMedium = 1,
                    DiameterOfVelusTerminal = 1,
                    LengthOfTelogenHair = 1,
                    RadiusOfFollicularUnits = 1,

                }
                );
        }
        [TestMethod]
        public void EditHairSizeSetting()
        {
            new HairSizeSettingsController().Edit(
               new HairSizeSettings
               {
                   HairSizeSettingsID = 1,
                   DiameterOfTerminalsMediumThick = 1,
                   DiameterOfTerminalsThinMedium = 1,
                   DiameterOfVelusTerminal = 1,
                   LengthOfTelogenHair = 1,
                   RadiusOfFollicularUnits = 1,

               }
               );
        }
        [TestMethod]
        public void GetByIdHairSizeSetting()
        {
            new HairSizeSettingsController().Get(1);
        }
        [TestMethod]
        public void GetHairSizeSetting()
        {
            new HairSizeSettingsController().Get();
        }
        [TestMethod]
        public void DeleteHairSizeSetting(int id)
        {
            new HairSizeSettingsController().Delete(1);
        }

    }
}
