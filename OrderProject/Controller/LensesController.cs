using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class LensesController 
    {
        public void Create(Lens lens)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Lenses.Add(lens);
                db.SaveChanges();
            }
        }
        public void Edit(Lens lens)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(lens).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                Lens lens = db.Lenses.Find(id);
                db.Lenses.Remove(lens);
                db.SaveChanges();
            }
        }
        public Lens Get(int id)
        {
            using (var db = new ApplicationDbContext())
                return db.Lenses.Find(id);
        }
        public IList<Lens> Get()
        {
            using (var db = new ApplicationDbContext())
                return db.Lenses.ToList();
        }
    }
}
