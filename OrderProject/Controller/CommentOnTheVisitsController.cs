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

        public void Create(CommentOnTheVisit commentOnTheVisit)
        {
            using (var db = new ApplicationDbContext())
            {
                db.CommentOnTheVisits.Add(commentOnTheVisit);
                db.SaveChanges();
            }
        }
        public void Edit(CommentOnTheVisit commentOnTheVisit)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(commentOnTheVisit).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                CommentOnTheVisit commentOnTheVisit = db.CommentOnTheVisits.Find(id);
                db.CommentOnTheVisits.Remove(commentOnTheVisit);
                db.SaveChanges();
            }
        }
        public CommentOnTheVisit Get(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                CommentOnTheVisit commentOnTheVisit = db.CommentOnTheVisits.Find(id);
                return commentOnTheVisit;
            }
        }
        public IList<CommentOnTheVisit> Get()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.CommentOnTheVisits.ToList();
            }
        }
    }
}
