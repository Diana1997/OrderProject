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
    public class VisitTest
    {

        [TestMethod]
        public void CreateVisit()
        {
            new VisitsController().Create(new Visit
            {
                UserID = 3,
                PatientID = 2,
                DateTime = DateTime.Now,
                ResearchID = 2,
            });
        }
        [TestMethod]
        public void EditVisit()
        {
            new VisitsController().Edit(new Visit
            {
                VisitID = 4,
                UserID = 3,
                PatientID = 2,
                DateTime = DateTime.Now,
                ResearchID = 2,
            });
        }
        [TestMethod]
        public void GetByIdVisit()
        {
            new VisitsController().Get(1);
        }
        [TestMethod]
        public void GetVisit()
        {
            new VisitsController().Get();

        }
        [TestMethod]
        public void DeleteVisit(int id)
        {
            new VisitsController().Delete(1);

        }

    }
}
