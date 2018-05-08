using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProject.Controller;
using OrderProject.Model;

namespace UnitTestProjectTest
{
    [TestClass]
    public class FieldOptionTest
    {
        [TestMethod]
        public void FieldOptionTest1()
        {
            FieldOption fieldOption;
            int id;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new FieldOptionsController(db);
                fieldOption = new FieldOption
                {
                    Title = "title",
                    Selected = true,
                    Text = "Text",
                };

                id = ctrl.Create(fieldOption);
                var fieldOptionRes = ctrl.Get(id);
                Assert.IsNotNull(fieldOptionRes);
                Assert.AreEqual("title", fieldOptionRes.Title);
                Assert.AreEqual(true, fieldOptionRes.Selected);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new FieldOptionsController(db);
                fieldOption = new FieldOption
                {
                    FieldOptionID = id,
                    Title = "title",
                    Selected = false,
                    Text = "Text",
                };
                ctrl.Edit(fieldOption);
                var fieldOptionRes = ctrl.Get(id);
                Assert.IsNotNull(fieldOptionRes);
                Assert.AreEqual("title", fieldOptionRes.Title);
                Assert.AreEqual(false, fieldOptionRes.Selected);
            }
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new FieldOptionsController(db);
                ctrl.Delete(fieldOption.FieldOptionID);
                var fieldOptionRes = ctrl.Get(id);
                Assert.IsNull(fieldOptionRes);
            }
        }
    }
}
