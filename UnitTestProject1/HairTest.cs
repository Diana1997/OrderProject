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
    public class HairTest
    {
        [TestMethod]
        public void CreateHair()
        {
            new HairController().Create(new Hair
            {
                Width = 1,
                X1 = 1,
                X2 = 2,
                Y1 = 1,
                Y2 = 3
            });
        }
        [TestMethod]
        public void EditHair()
        {
            new HairController().Edit(new Hair
            {
                HairID = 1,
                Width = 1,
                X1 = 1,
                X2 = 5,
                Y1 = 1,
                Y2 = 3
            });
        }
        [TestMethod]
        public void GetHairById()
        {
            new HairController().Get(1);
        }
        [TestMethod]
        public void GetHair()
        {
            new HairController().Get(1);
        }
        [TestMethod]
        public void DeleteHair()
        {
            new HairController().Delete(1);
        }

    }
}
