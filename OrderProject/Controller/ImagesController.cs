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
        ApplicationDbContext db { get; set; }

        public ImagesController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public int Create(Image image)
        {

            db.Images.Add(image);
            db.SaveChanges();
            return image.ImageID;
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
            return db.Images.Find(id);
        }
        public IList<Image> Get()
        {
            return db.Images.ToList();
        }
    }
}
