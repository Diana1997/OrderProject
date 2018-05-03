using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class SettingsController
    {
        public void Create(Setting setting)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Settings.Add(setting);
                db.SaveChanges();
            }
        }
        public void Edit(Setting setting)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(setting).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                Setting setting = db.Settings.Find(id);
                db.Settings.Remove(setting);
                db.SaveChanges();
            }
        }

        public Setting Get(int id)
        {
            using (var db = new ApplicationDbContext())
                return db.Settings.Include(s => s.HairSizeSettings).Include(s => s.StatisticalSettings).First();
        }
        public IList<Setting> Get()
        {
            using (var db = new ApplicationDbContext())
                return db.Settings.Include(s => s.HairSizeSettings).Include(s => s.StatisticalSettings).ToList();
        }
    }

}
