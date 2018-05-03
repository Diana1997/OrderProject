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
    public class ImageTest
    {
        [TestMethod]
        public void CreateImage()
        {
            new ImagesController().Create(
                new Image
                {
                    DateTime = DateTime.Now,
                    Title = "title",
                    ImageContent = new byte[2] { 0, 1 },
                }
                );
        }
        [TestMethod]
        public void EditImage()
        {
            new ImagesController().Create(
                new Image
                {
                    ImageID = 1,
                    DateTime = DateTime.Now,
                    Title = "title",
                    ImageContent = new byte[2] { 0, 1 },
                }
                );
        }
        [TestMethod]
        public void GetByIdImage()
        {
            new ImagesController().Get(1);
        }
        [TestMethod]
        public void GetImage()
        {
            new ImagesController().Get();
        }
        [TestMethod]
        public void DeleteImage(int id)
        {
            new ImagesController().Delete(1);
        }

    }
}
