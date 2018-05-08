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
    public class CommentOnTheVisitTest
    {
        [TestMethod]
        public void CommentOnTheVisitTest1()
        {
            CommentOnTheVisit commentOnTheVisit;
            int id;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new CommentOnTheVisitsController(db);
                commentOnTheVisit = new CommentOnTheVisit()
                {
                     Comment = "Comment",
                      TypeOfComment = TypeOfComment.AdministratoroTheDoctor,
                };

                id = ctrl.Create(commentOnTheVisit);
                var commentOnTheVisitRes = ctrl.Get(id);
                Assert.IsNotNull(commentOnTheVisitRes);
                Assert.AreEqual("Comment", commentOnTheVisitRes.Comment);
                Assert.AreEqual(TypeOfComment.AdministratoroTheDoctor, commentOnTheVisitRes.TypeOfComment);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new CommentOnTheVisitsController(db);
                commentOnTheVisit = new CommentOnTheVisit()
                {
                    CommentOnTheVisitID = id,
                    Comment = "Comment",
                    TypeOfComment = TypeOfComment.DoctorAdministrator,
                };
                ctrl.Edit(commentOnTheVisit);
                var commentOnTheVisitRes = ctrl.Get(id);
                Assert.IsNotNull(commentOnTheVisitRes);
                Assert.AreEqual("Comment", commentOnTheVisitRes.Comment);
                Assert.AreEqual(TypeOfComment.DoctorAdministrator, commentOnTheVisitRes.TypeOfComment);
            }
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new CommentOnTheVisitsController(db);
                ctrl.Delete(commentOnTheVisit.CommentOnTheVisitID);
                var commentOnTheVisitRes = ctrl.Get(id);
                Assert.IsNull(commentOnTheVisitRes);
            }
        }
    }
}
