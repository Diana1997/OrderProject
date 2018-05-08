using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProject.Controller;
using OrderProject.Model;


namespace UnitTestProjectTest
{
    [TestClass]
    public class PictureTest
    {
        [TestMethod]
        public void PictureTest1()
        {
            Picture picture;
            int id;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new PicturesController(db);
                picture = new Picture
                {
                    Title = "title",
                    Selected = true,
                    Data = new byte[1] { 0 },
                };

                id = ctrl.Create(picture);
                var pictureRes = ctrl.Get(id);
                Assert.IsNotNull(pictureRes);
                Assert.AreEqual("title", pictureRes.Title);
                Assert.AreEqual(true, pictureRes.Selected);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new PicturesController(db);
                picture = new Picture
                {
                    PictureID = id,
                    Title = "title11",
                    Selected = false,
                    Data = new byte[1] { 0 },
                };
                ctrl.Edit(picture);
                var pictureRes = ctrl.Get(id);
                Assert.IsNotNull(pictureRes);
                Assert.AreEqual("title11", pictureRes.Title);
                Assert.AreEqual(false, pictureRes.Selected);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new PicturesController(db);

                ctrl.Delete(picture.PictureID);
                var pictureRes = ctrl.Get(id);
                Assert.IsNull(pictureRes);
            }
        }
    }
}

