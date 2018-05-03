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
    public class ReportFieldTest
    {
        [TestMethod]
        public void CreateReportField()
        {
            new ReportFieldsController().Create(
                new ReportField
                {
                    Name = "name",
                    FieldType = FieldType.Conclusion,
                    FieldOptionID = 1,
                });
        }
        [TestMethod]
        public void EditReportField()
        {
            new ReportFieldsController().Edit(
              new ReportField
              {
                  ReportFieldID = 2,
                  Name = "name",
                  FieldType = FieldType.DescriptionOfTheClinic,
                  FieldOptionID = 1,
              });
        }
        [TestMethod]
        public void GetByIdReportField()
        {
            new ReportFieldsController().Get(2);
        }
        [TestMethod]
        public void GetReportField()
        {
            new ReportFieldsController().Get();

        }
        [TestMethod]
        public void DeleteReportField(int id)
        {
            new ReportFieldsController().Delete(2);

        }

    }
}
