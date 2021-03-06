﻿using System;
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
    public class HairTest
    {
        [TestMethod]
        public void HairTest1()
        {
            Hair hair;
            int id;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new HairController(db);
                hair = new Hair()
                {
                    Width = 1,
                    X1 = 1,
                    X2 = 1,
                    Y1 = 1,
                    Y2 = 1,
                };

                id = ctrl.Create(hair);
                var hairRes = ctrl.Get(id);
                Assert.IsNotNull(hair);
                Assert.AreEqual(1, hairRes.X1);
                Assert.AreEqual(1, hairRes.X2);
                Assert.AreEqual(1, hairRes.Y1);
                Assert.AreEqual(1, hairRes.Y2);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new HairController(db);
                hair = new Hair()
                {
                    HairID = id,
                    Width = 1,
                    X1 = 2,
                    X2 = 1,
                    Y1 = 1,
                    Y2 = 1,
                };
                ctrl.Edit(hair);
                var hairRes  = ctrl.Get(id);
                Assert.IsNotNull(hair);
                Assert.AreEqual(2, hairRes.X1);
                Assert.AreEqual(1, hairRes.X2);
                Assert.AreEqual(1, hairRes.Y1);
                Assert.AreEqual(1, hairRes.Y2);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new HairController(db);

                ctrl.Delete(hair.HairID);

                // check results
                var hairRes = ctrl.Get(id);

                Assert.IsNull(hairRes);
            }
        }
    }
}
