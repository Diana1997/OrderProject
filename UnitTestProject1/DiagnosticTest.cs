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
    public class DiagnosticTest
    {
        [TestMethod]
        public void CreateDiagnostic()
        {
            new DiagnosticsController().Create(
                new Diagnostic
                {
                    DiagnosticText = "text",
                    CreationDate = DateTime.Now,
                    DateOfLastConfirmation = DateTime.Now,
                    Comment = "comment"
                }
                );
        }
        [TestMethod]
        public void EditDiagnostic()
        {
            new DiagnosticsController().Create(
               new Diagnostic
               {
                   DiagnosticID = 1,
                   DiagnosticText = "text",
                   CreationDate = DateTime.Now,
                   DateOfLastConfirmation = DateTime.Now,
                   Comment = "comment"
               }
               );
        }
        [TestMethod]
        public void GetByIdDiagnostic()
        {
            new DiagnosticsController().Get(1);
        }
        [TestMethod]
        public void GetDiagnostic()
        {
            new DiagnosticsController().Get();
        }
        [TestMethod]
        public void DeleteDiagnostic(int id)
        {
            new DiagnosticsController().Delete(1);
        }

    }
}
