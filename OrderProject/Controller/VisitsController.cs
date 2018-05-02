using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class VisitsController : IDisposable
    {
        private ApplicationDbContext db;
        public VisitsController()
        {
            db = new ApplicationDbContext();
        }
        public void Create(Visit visit)
        {
            db.Visits.Add(visit);
            db.SaveChanges();
        }
        public void Edit(Visit visit)
        {
            db.Entry(visit).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Visit visit = db.Visits.Find(id);
            db.Visits.Remove(visit);
            db.SaveChanges();
        }
        public Visit Get(int id)
        {
            return db.Visits.Include(v => v.Patient).Include(v => v.Research).Include(v => v.User).First();
        }
        public IList<Visit> Get()
        {
            return db.Visits.Include(v => v.Patient).Include(v => v.Research).Include(v => v.User).ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
