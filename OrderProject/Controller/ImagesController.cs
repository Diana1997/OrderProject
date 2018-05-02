using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class ImagesController : IDisposable
    {
        private ApplicationDbContext db;
        public ImagesController()
        {
            db = new ApplicationDbContext();
        }
        public void Create(Image image)
        {
            db.Images.Add(image);
            db.SaveChanges();
        }
        public void Edit(Image image)
        {
            db.Entry(image).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
        }

        public Image Get(int id)
        {
            Image image = db.Images.Find(id);
            return image;
        }
        public IList<Image> Get()
        {
            return db.Images.ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
