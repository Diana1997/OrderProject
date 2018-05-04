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
        ApplicationDbContext db { get; set; }

        public PicturesController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public int Create(Picture picture)
        {
            db.Pictures.Add(picture);
            db.SaveChanges();
            return picture.PictureID;
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
            return db.Pictures.Find(id);
        }
        public IList<Picture> Get()
        {
            return db.Pictures.ToList();
        }
    }
}
