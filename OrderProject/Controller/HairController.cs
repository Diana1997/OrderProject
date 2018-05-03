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
        public void Create(Hair hair)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Hairs.Add(hair);
                db.SaveChanges();
            }
        }
        public void Edit(Hair hair)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(hair).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                Hair hair = db.Hairs.Find(id);
                db.Hairs.Remove(hair);
                db.SaveChanges();
            }
        }
        public Hair Get(int id)
        {
            using (var db = new ApplicationDbContext())
                return db.Hairs.Find(id);
        }
        public IList<Hair> Get()
        {
            using (var db = new ApplicationDbContext())
                return db.Hairs.ToList();
        }
    }
}
