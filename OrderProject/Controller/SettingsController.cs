using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class SettingsController : IDisposable
    {
        private ApplicationDbContext db;
        public SettingsController()
        {
            db = new ApplicationDbContext();
        }
        public void Create(Setting setting)
        {
            db.Settings.Add(setting);
            db.SaveChanges();
        }
        public void Edit(Setting setting)
        {
            db.Entry(setting).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Setting setting = db.Settings.Find(id);
            db.Settings.Remove(setting);
            db.SaveChanges();
        }

        public Setting Get(int id)
        {
           return db.Settings.Include(s => s.HairSizeSettings).Include(s => s.StatisticalSettings).First();
        }
        public IList<Setting> Get()
        {
            return db.Settings.Include(s => s.HairSizeSettings).Include(s => s.StatisticalSettings).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }

}
