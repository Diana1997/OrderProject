using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class PicturesController 
    {
        public void Create(Picture picture)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Pictures.Add(picture);
                db.SaveChanges();
            }
        }
        public void Edit(Picture picture)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(picture).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                Picture picture = db.Pictures.Find(id);
                db.Pictures.Remove(picture);
                db.SaveChanges();
            }
        }
        public Picture Get(int id)
        {
            using (var db = new ApplicationDbContext())
               return db.Pictures.Find(id);
        }
        public IList<Picture> Get()
        {
            using (var db = new ApplicationDbContext())
                return db.Pictures.ToList();
        }
    }
}
