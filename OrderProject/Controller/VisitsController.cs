using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class VisitsController
    {
        public void Create(Visit visit)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Visits.Add(visit);
                db.SaveChanges();
            }
        }
        public void Edit(Visit visit)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                Visit visit = db.Visits.Find(id);
                db.Visits.Remove(visit);
                db.SaveChanges();
            }
        }
        public Visit Get(int id)
        {
            using (var db = new ApplicationDbContext())
                return db.Visits.Include(v => v.Patient).Include(v => v.Research).Include(v => v.User).First();
        }
        public IList<Visit> Get()
        {
            using (var db = new ApplicationDbContext())
                return db.Visits.Include(v => v.Patient).Include(v => v.Research).Include(v => v.User).ToList();
        }
    }
}
