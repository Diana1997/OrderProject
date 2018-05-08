using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProject.Controller;
using OrderProject.Model;

namespace UnitTestProjectTest
{
    [TestClass]
    public class ReportFieldTest
    {
        [TestMethod]
        public void ReportFieldTest1()
        {
            ReportField reportField;
            int id;

            int fieldOptionID;

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new FieldOptionsController(db);
               var  fieldOption = new FieldOption
                {
                    Title = "title",
                    Selected = true,
                    Text = "Text",
                };

                fieldOptionID = ctrl.Create(fieldOption);
                var fieldOptionRes = ctrl.Get(fieldOptionID);
                Assert.IsNotNull(fieldOptionRes);
            }
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new ReportFieldsController(db);
                reportField = new ReportField
                {
                    Name = "name",
                    FieldType = FieldType.Conclusion,
                    FieldOptionID = fieldOptionID,
                };

                id = ctrl.Create(reportField);
                var reportFieldRes = ctrl.Get(id);
                Assert.IsNotNull(reportFieldRes);
                Assert.AreEqual("name", reportFieldRes.Name);
                Assert.AreEqual(FieldType.Conclusion, reportFieldRes.FieldType);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new ReportFieldsController(db);
                reportField = new ReportField
                {
                    ReportFieldID = id,
                    Name = "name",
                    FieldType = FieldType.DescriptionOfTheClinic,
                    FieldOptionID = fieldOptionID,
                };
                ctrl.Edit(reportField);
                var reportFieldRes = ctrl.Get(id);
                Assert.IsNotNull(reportFieldRes);
                Assert.AreEqual("name", reportFieldRes.Name);
                Assert.AreEqual(FieldType.DescriptionOfTheClinic, reportFieldRes.FieldType);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new ReportFieldsController(db);

                ctrl.Delete(reportField.ReportFieldID);
                var reportFieldRes = ctrl.Get(id);
                Assert.IsNull(reportFieldRes);
            }
        }
    }
}
