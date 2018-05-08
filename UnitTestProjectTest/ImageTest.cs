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
    public class ImageTest
    {
        [TestMethod]
        public void ImageTest1()
        {
            Image image;
            int id;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new ImagesController(db);
                image = new Image()
                {
                    DateTime = DateTime.Now,
                    Title = "title",
                    ImageContent = new byte[2] { 0, 1 },
                };

                id = ctrl.Create(image);
                var imageRes = ctrl.Get(id);
                Assert.IsNotNull(imageRes);
                Assert.AreEqual("title", imageRes.Title);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new ImagesController(db);
                image = new Image()
                {
                    ImageID = id,
                    DateTime = DateTime.Now,
                    Title = "name",
                    ImageContent = new byte[2] { 0, 1 },
                };
                ctrl.Edit(image);
                var imageRes = ctrl.Get(id);
                Assert.IsNotNull(imageRes);
                Assert.AreEqual("name", imageRes.Title);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new ImagesController(db);

                ctrl.Delete(image.ImageID);

                // check results
                var imageRes = ctrl.Get(id);

                Assert.IsNull(imageRes);
            }
        }
    }
}
