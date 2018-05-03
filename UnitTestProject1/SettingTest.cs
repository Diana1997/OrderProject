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
    public class SettingTest
    {
        [TestMethod]
        public void CreateSetting()
        {
            new SettingsController().Create(
                new Setting
                {
                    HairSizeSettingsID = 1,
                    StatisticalSettingsID = 2
                }
            );
        }
        [TestMethod]
        public void EditSetting()
        {
            new SettingsController().Edit(
               new Setting
               {
                   HairSizeSettingsID = 1,
                   StatisticalSettingsID = 2
               }
           );
        }
        [TestMethod]
        public void GetByIdSetting()
        {
            new SettingsController().Get(1);
        }
        [TestMethod]
        public void GetSetting()
        {
            new SettingsController().Get();
        }
        [TestMethod]
        public void DeleteSetting(int id)
        {
            new SettingsController().Delete(1);
        }

    }
}
