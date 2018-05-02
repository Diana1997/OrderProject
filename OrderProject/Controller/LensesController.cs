using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class LensesController : IDisposable
    {
        private ApplicationDbContext db;

        public LensesController()
        {
            db = new ApplicationDbContext();
        }
        public void Create(Lens lens)
        {
            db.Lenses.Add(lens);
            db.SaveChanges();
        }
        public void Edit(Lens lens)
        {
            db.Entry(lens).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Lens lens = db.Lenses.Find(id);
            db.Lenses.Remove(lens);
            db.SaveChanges();
        }
        public Lens Get(int id)
        {
            Lens lens = db.Lenses.Find(id);
            return lens;
        }
        public IList<Lens> Get()
        {
            return db.Lenses.ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
