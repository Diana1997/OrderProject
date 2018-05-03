using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class HairSizeSettingsController
    {
        public void Create(HairSizeSettings hairSizeSettings)
        {
            using (var db = new ApplicationDbContext())
            {
                db.HairSizeSettings.Add(hairSizeSettings);
                db.SaveChanges();
            }
        }

        public void Edit(HairSizeSettings hairSizeSettings)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(hairSizeSettings).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                HairSizeSettings hairSizeSettings = db.HairSizeSettings.Find(id);
                db.HairSizeSettings.Remove(hairSizeSettings);
                db.SaveChanges();
            }
        }
        public HairSizeSettings Get(int id)
        {
            using (var db = new ApplicationDbContext())
                return db.HairSizeSettings.Find(id);
        }
        public IList<HairSizeSettings> Get()
        {
            using (var db = new ApplicationDbContext())
                return db.HairSizeSettings.ToList();
        }
    }
}
