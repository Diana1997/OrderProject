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
    public class DiagnosticsTest
    {
        [TestMethod]
        public void DiagnosticsTest1()
        {
            Diagnostic diagnostic;
            int id;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new DiagnosticsController(db);
                diagnostic = new Diagnostic
                {
                    DiagnosticText = "text",
                    CreationDate = DateTime.Now,
                    DateOfLastConfirmation = DateTime.Now,
                    Comment = "comment",
                };

                id = ctrl.Create(diagnostic);
                var diagnosticRes = ctrl.Get(id);
                Assert.IsNotNull(diagnosticRes);
                Assert.AreEqual("text", diagnosticRes.DiagnosticText);
                Assert.AreEqual("comment", diagnosticRes.Comment);

            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new DiagnosticsController(db);
                diagnostic = new Diagnostic
                {
                    DiagnosticID = id,
                    DiagnosticText = "text",
                    CreationDate = DateTime.Now,
                    DateOfLastConfirmation = DateTime.Now,
                    Comment = "comment",
                };

                ctrl.Edit(diagnostic);
                var diagnosticRes = ctrl.Get(id);
                Assert.IsNotNull(diagnosticRes);
                Assert.AreEqual("text", diagnosticRes.DiagnosticText);
                Assert.AreEqual("comment", diagnosticRes.Comment);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new DiagnosticsController(db);

                ctrl.Delete(diagnostic.DiagnosticID);
                var diagnosticRes = ctrl.Get(id);
                Assert.IsNull(diagnosticRes);
            }
        }
    }
}
