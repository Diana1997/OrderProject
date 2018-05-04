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
        ApplicationDbContext db { get; set; }

        public LensesController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public int Create(Lens lens)
        {
            db.Lenses.Add(lens);
            db.SaveChanges();
            return lens.LensID;
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
            return db.Lenses.Find(id);
        }
        public IList<Lens> Get()
        {
            return db.Lenses.ToList();
        }
    }
}
