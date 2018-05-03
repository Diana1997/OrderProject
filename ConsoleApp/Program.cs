using OrderProject.Controller;
using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //CommentOnTheVisitsController con = new CommentOnTheVisitsController();
            //con.Create(new CommentOnTheVisit
            //{
            //    Comment = "Commen",
            //    TypeOfComment = TypeOfComment.AdministratoroTheDoctor
            //});
            //CommentOnTheVisit c = con.Get(1);
            //Console.WriteLine(c.Comment + " " + c.TypeOfComment);
            //con.Edit(new CommentOnTheVisit
            //{
            //    CommentOnTheVisitID = 1,
            //    Comment = "Commen",
            //    TypeOfComment = TypeOfComment.AdministratorYourself
            //});
            //CommentOnTheVisit c1 = con.Get(1);
            //Console.WriteLine(c1.Comment + " " + c1.TypeOfComment);
            //Console.ReadLine();


            //new DiagnosticsController().Create(
            //    new Diagnostic
            //    {
            //        DiagnosticText = "text",
            //        CreationDate = DateTime.Now,
            //        DateOfLastConfirmation = DateTime.Now,
            //        Comment = "comment"
            //    }
            //    );
            //Diagnostic diagnostic = new DiagnosticsController().Get(1);
            //Console.WriteLine(diagnostic.DiagnosticID + " " + diagnostic.DiagnosticText);
            new DiagnosticsController().Delete(1);
            Console.WriteLine("end");
            Console.ReadLine();
        }
    }
}
