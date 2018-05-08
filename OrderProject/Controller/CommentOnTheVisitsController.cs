using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderProject.Controller
{

    public class CommentOnTheVisitsController
    {
        ApplicationDbContext db { get; set; }

        public CommentOnTheVisitsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public int  Create(CommentOnTheVisit commentOnTheVisit)
        {
            db.CommentOnTheVisits.Add(commentOnTheVisit);
            db.SaveChanges();
            return commentOnTheVisit.CommentOnTheVisitID;
        }
        public void Edit(CommentOnTheVisit commentOnTheVisit)
        {

            db.Entry(commentOnTheVisit).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {

            CommentOnTheVisit commentOnTheVisit = db.CommentOnTheVisits.Find(id);
            db.CommentOnTheVisits.Remove(commentOnTheVisit);
            db.SaveChanges();
        }
        public CommentOnTheVisit Get(int id)
        {
           return db.CommentOnTheVisits.Find(id);
        }
        public IList<CommentOnTheVisit> Get()
        {
            return db.CommentOnTheVisits.ToList();
        }
    }
}
