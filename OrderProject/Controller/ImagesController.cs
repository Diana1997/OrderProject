using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class ImagesController
    {
     
        public void Create(Image image)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Images.Add(image);
                db.SaveChanges();
            }
        }
        public void Edit(Image image)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                Image image = db.Images.Find(id);
                db.Images.Remove(image);
                db.SaveChanges();
            }
        }

        public Image Get(int id)
        {
            using (var db = new ApplicationDbContext())
                return db.Images.Find(id);
        }
        public IList<Image> Get()
        {
            using (var db = new ApplicationDbContext())
                return db.Images.ToList();
        }
    }
}
