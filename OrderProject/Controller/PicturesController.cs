using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class PicturesController : IDisposable
    {
        private ApplicationDbContext db;
        public PicturesController()
        {
            db = new ApplicationDbContext();
        }
        public void Create(Picture picture)
        {
            db.Pictures.Add(picture);
            db.SaveChanges();
        }
        public void Edit(Picture picture)
        {
            db.Entry(picture).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Picture picture = db.Pictures.Find(id);
            db.Pictures.Remove(picture);
            db.SaveChanges();
        }
        public Picture Get(int id)
        {
            Picture picture = db.Pictures.Find(id);
            return picture;
        }
        public IList<Picture> Get()
        {
            return db.Pictures.ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
