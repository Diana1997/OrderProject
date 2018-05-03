using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class StatisticalSettingsController
    {
        public void Create(StatisticalSettings statisticalSettings)
        {
            using (var db = new ApplicationDbContext())
            {
                db.StatisticalSettings.Add(statisticalSettings);
                db.SaveChanges();
            }
        }
        public void Edit(StatisticalSettings statisticalSettings)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(statisticalSettings).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                StatisticalSettings statisticalSettings = db.StatisticalSettings.Find(id);
                db.StatisticalSettings.Remove(statisticalSettings);
                db.SaveChanges();
            }
        }
        public StatisticalSettings Get(int id)
        {
            using (var db = new ApplicationDbContext())
                return db.StatisticalSettings.Find(id);
        }
        public IList<StatisticalSettings> Get()
        {
            using (var db = new ApplicationDbContext())
                return db.StatisticalSettings.ToList();
        }
    }
}
