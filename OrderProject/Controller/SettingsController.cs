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
        ApplicationDbContext db { get; set; }

        public SettingsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public int Create(Setting setting)
        {
            db.Settings.Add(setting);
            db.SaveChanges();
            return setting.SettingsID;
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
            return db.Settings.Include(s => s.HairSizeSettings).Include(s => s.StatisticalSettings).FirstOrDefault( x => x.SettingsID == id);
        }
        public IList<Setting> Get()
        {
            return db.Settings.Include(s => s.HairSizeSettings).Include(s => s.StatisticalSettings).ToList();
        }
    }

}
