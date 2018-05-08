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
    public class LensTest
    {
        [TestMethod]
        public void LensTest1()
        {
            Lens lens;
            int id;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new LensesController(db);
                lens = new Lens()
                {
                    Name = "name",
                    Scale = 1
                };

                id = ctrl.Create(lens);
                var lensRes = ctrl.Get(id);
                Assert.IsNotNull(lensRes);
                Assert.AreEqual("name", lensRes.Name);
                Assert.AreEqual(1, lensRes.Scale);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new LensesController(db);
                lens = new Lens()
                {
                    LensID = id,
                    Name = "name",
                    Scale = 2
                };
                ctrl.Edit(lens);
                var lensRes = ctrl.Get(id);
                Assert.IsNotNull(lensRes);
                Assert.AreEqual("name", lensRes.Name);
                Assert.AreEqual(2, lensRes.Scale);
            }
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new LensesController(db);
                ctrl.Delete(lens.LensID);
                var lensRes = ctrl.Get(id);
                Assert.IsNull(lensRes);
            }
        }
    }
}
