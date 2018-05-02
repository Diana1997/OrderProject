using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class HairController : IDisposable
    {
        private ApplicationDbContext db;

        public HairController()
        {
            db = new ApplicationDbContext();
        }
        public void Create(Hair hair)
        {
            db.Hairs.Add(hair);
            db.SaveChanges();
        }
        public void Edit(Hair hair)
        {
            db.Entry(hair).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Hair hair = db.Hairs.Find(id);
            db.Hairs.Remove(hair);
            db.SaveChanges();
        }
        public Hair Get(int id)
        {
            Hair hair = db.Hairs.Find(id);
            return hair;
        }
        public IList<Hair> Get()
        {
            return db.Hairs.ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
