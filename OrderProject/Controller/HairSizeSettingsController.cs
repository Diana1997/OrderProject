using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class HairSizeSettingsController : IDisposable
    {
        private ApplicationDbContext db;

        public HairSizeSettingsController()
        {
            db= new ApplicationDbContext();
        }
        public void Create(HairSizeSettings hairSizeSettings)
        {
            db.HairSizeSettings.Add(hairSizeSettings);
            db.SaveChanges();
        }

        public void Edit(HairSizeSettings hairSizeSettings)
        {
            db.Entry(hairSizeSettings).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            HairSizeSettings hairSizeSettings = db.HairSizeSettings.Find(id);
            db.HairSizeSettings.Remove(hairSizeSettings);
            db.SaveChanges();
        }
        public HairSizeSettings Get(int id)
        {
            HairSizeSettings hairSizeSettings = db.HairSizeSettings.Find(id);
            return hairSizeSettings;
        }
        public IList<HairSizeSettings> Get()
        {
            return db.HairSizeSettings.ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
