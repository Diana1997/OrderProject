using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProject.Controller;
using OrderProject.Model;
using System.Data.Entity;

namespace UnitTestProject1
{

   
    [TestClass]
    public class CommentOnTheVisitsControllerTest
    {
        [TestMethod]
        public void CommentOnTheVisitsControllerCreateTestMethod()
        {
            CommentOnTheVisitsController con = new CommentOnTheVisitsController();
            con.Create(new CommentOnTheVisit
            {
                Comment = "Commen",
                TypeOfComment = TypeOfComment.AdministratoroTheDoctor
            });
        }
        [TestMethod]
        public void GetByIdCommentOnTheVisits()
        {
            CommentOnTheVisitsController con = new CommentOnTheVisitsController();
            con.Get(1);
        }
        [TestMethod]
        public void GetAllCommentOnTheVisits()
        {
            CommentOnTheVisitsController con = new CommentOnTheVisitsController();
            con.Get();
        }
        [TestMethod]
        public void EditCommentOnTheVisits()
        {
            CommentOnTheVisitsController con = new CommentOnTheVisitsController();
            con.Edit(new CommentOnTheVisit
            {
                CommentOnTheVisitID = 1,
                Comment = "Commen",
                TypeOfComment = TypeOfComment.AdministratorYourself
            });
        }
        [TestMethod]
        public void DeleteCommentOnTheVisits()
        {
            CommentOnTheVisitsController con = new CommentOnTheVisitsController();
            con.Get(1);
        }
    }
    
}
