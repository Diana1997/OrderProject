using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class CommentOnTheVisitsController : IDisposable
    {
        private ApplicationDbContext db;
        public CommentOnTheVisitsController()
        {
            db = new ApplicationDbContext();
        }
        public void Create(CommentOnTheVisit commentOnTheVisit)
        {
            db.CommentOnTheVisits.Add(commentOnTheVisit);
            db.SaveChanges();
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
            CommentOnTheVisit commentOnTheVisit = db.CommentOnTheVisits.Find(id);
            return commentOnTheVisit;
        }
        public IList<CommentOnTheVisit> Get()
        {
            return db.CommentOnTheVisits.ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
