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
    public class LensTest
    {
        [TestMethod]
        public void CreateLens()
        {
            new LensesController().Create(
                new Lens()
                {
                    Name = "name",
                    Scale = 1
                }
                );
        }
        [TestMethod]
        public void EditLens()
        {
            new LensesController().Create(
                new Lens()
                {
                    LensID = 1,
                    Name = "name",
                    Scale = 1
                }
                );
        }

        [TestMethod]
        public void GetLensById()
        {
            new LensesController().Get(1);
        }
        [TestMethod]
        public void GetLens()
        {
            new LensesController().Get();
        }
        [TestMethod]
        public void DeleteLens()
        {
            new LensesController().Delete(1);
        }
    }
}
