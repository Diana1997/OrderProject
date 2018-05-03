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
    public class PictureTest
    {
        [TestMethod]
        public void CreatePicture()
        {
            new PicturesController().Create(
                new Picture
                {
                    Title = "title",
                    Selected = true,
                    Data = new byte[1] { 0 },
                }
                );
        }
        [TestMethod]
        public void EditPicture()
        {
            new PicturesController().Edit(
              new Picture
              {
                  PictureID = 1,
                  Title = "title",
                  Selected = true,
                  Data = new byte[1] { 0 },
              }
              );
        }
        [TestMethod]
        public void GetByIdPicture()
        {
            new PicturesController().Get(1);
        }
        [TestMethod]
        public void GetPicture()
        {
            new PicturesController().Get();
        }
        [TestMethod]
        public void DeletePicture(int id)
        {
            new PicturesController().Delete(1);
        }

    }
}
