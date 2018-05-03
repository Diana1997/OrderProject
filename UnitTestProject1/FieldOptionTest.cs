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
    public class FieldOptionTest
    {
        [TestMethod]
        public void CreateFieldOption()
        {
            new FieldOptionsController().Create(
                new FieldOption {
                     Title = "title",
                      Selected = true,
                       Text = "Text",
                }
                );
        }
        [TestMethod]
        public void EditFieldOption()
        {
            new FieldOptionsController().Edit(
              new FieldOption
              {
                  FieldOptionID = 1,
                  Title = "title",
                  Selected = true,
                  Text = "Text",
              }
          );
        }
        [TestMethod]
        public void GetByIdFieldOption()
        {
            new FieldOptionsController().Get(1);
        }
        [TestMethod]
        public void GetFieldOption()
        {
            new FieldOptionsController().Get();
        }
        [TestMethod]
        public void DeleteFieldOption(int id)
        {
            new FieldOptionsController().Delete(1);
        }

    }
}
