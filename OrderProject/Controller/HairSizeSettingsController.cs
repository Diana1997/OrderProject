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
        ApplicationDbContext db { get; set; }

        public HairSizeSettingsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public int Create(HairSizeSettings hairSizeSettings)
        {
            db.HairSizeSettings.Add(hairSizeSettings);
            db.SaveChanges();
            return hairSizeSettings.HairSizeSettingsID;
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
            return db.HairSizeSettings.Find(id);
        }
        public IList<HairSizeSettings> Get()
        {
            return db.HairSizeSettings.ToList();
        }
    }
}
