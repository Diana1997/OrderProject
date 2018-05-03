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
    public class ResearchTest
    {

        [TestMethod]
        public void CreateResearch()
        {
            new ResearchesController().Create(
                new Research
                {
                    ResearchType = ResearchType.Phototrichogram,
                    StateOfTheResearch = StateOfTheResearch.Completed,
                    Thumbnail = new byte[1] {0},
                    ImageID = 1,
                    HairID = 2,
                    ResearchArea = 1,
                    SettingID = 2,
                    LensID = 2,
                    ResearchTime =DateTime.Now,
                }
                );
        }
        [TestMethod]
        public void EditResearch()
        {
            new ResearchesController().Edit(
               new Research
               {
                   ResearchID = 2,
                   ResearchType = ResearchType.Phototrichogram,
                   StateOfTheResearch = StateOfTheResearch.Completed,
                   Thumbnail = new byte[1] { 0 },
                   ImageID = 1,
                   HairID = 2,
                   ResearchArea = 1,
                   SettingID = 2,
                   LensID = 2,
                   ResearchTime = DateTime.Now,

               }
            );
        }
        [TestMethod]
        public void DeleteResearch(int id)
        {
            new ResearchesController().Delete(1);
        }

    }
}
